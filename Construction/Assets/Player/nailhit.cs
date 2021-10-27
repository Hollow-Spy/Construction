using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailhit : MonoBehaviour
{

    ConfigurableJoint thejoint;
    JointDrive oldx,oldy;
    JointDrive newx, newy;
    [SerializeField] float time;
    


  public void deflate(GameObject hit)
    {
      


        transform.SetParent(hit.transform);

       thejoint = hit.GetComponent<ConfigurableJoint>();
        if (thejoint.angularYZDrive.positionSpring <= 0 || thejoint.angularYZDrive.positionSpring <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
           

            oldx.maximumForce = thejoint.angularXDrive.maximumForce;
            newx = oldx;
            oldx.positionSpring = thejoint.angularXDrive.positionSpring;


            oldy.maximumForce = thejoint.angularYZDrive.maximumForce;
            newy = oldy;
            oldy.positionSpring = thejoint.angularYZDrive.positionSpring;





            thejoint.angularXDrive = newx;
            thejoint.angularYZDrive = newy;

        }

    }

    private void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            thejoint.angularXDrive = oldx;
            thejoint.angularYZDrive = oldy;
            Destroy(gameObject);
        }
    }
}
