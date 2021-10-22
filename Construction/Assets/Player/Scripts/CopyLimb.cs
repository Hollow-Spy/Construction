using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLimb : MonoBehaviour
{
    [SerializeField] private Transform targetLimb;
    [SerializeField] private ConfigurableJoint m_ConfigurableJoint;
  

    float ogangularX, ogangularYZ;
     bool ragdolled;
    Quaternion targetInitialRotation;
    float time;
    Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
    
        this.m_ConfigurableJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
        ogangularYZ = m_ConfigurableJoint.angularYZDrive.positionSpring;
        ogangularX = m_ConfigurableJoint.angularXDrive.positionSpring;

    }
  
        

    public  void Ragdoll()
    {
        var spring = m_ConfigurableJoint.angularXDrive;
        var spring2 =  m_ConfigurableJoint.angularYZDrive;
        
     if (ragdolled)
        {
            spring.positionSpring = ogangularX;
            spring2.positionSpring = ogangularYZ;
            ragdolled = false;
            time = 2;

        }
        else
        {
            ogPos = transform.localPosition;
            ragdolled = true;
            spring.positionSpring = 0;
            spring2.positionSpring = 0;

          



        }
    
        m_ConfigurableJoint.angularXDrive = spring2;
        m_ConfigurableJoint.angularYZDrive = spring;
    }
    

    private void FixedUpdate()
    {
     
        if(!ragdolled)
        {
            this.m_ConfigurableJoint.targetRotation = copyRotation();

        }

        if (time > 0)
        {
            this.m_ConfigurableJoint.targetPosition = ogPos;
        }
        else
        {
            this.m_ConfigurableJoint.targetPosition = Vector3.zero;
            time -= Time.deltaTime;
        }



    }

    private Quaternion copyRotation()
    {
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
    
}
