using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public PlayerController playercontroller;
    [SerializeField] bool RightHand;
    bool grabbing;
    [SerializeField] LayerMask movablemask, unmovable,charactermask;
    SpringJoint handspringjoint;
    HingeJoint objectspringjoint;


    private void Update()
    {
        if(!RightHand)
        {
            if (!playercontroller.isLeftArmUp)
            {
                grabbing = false;

                if (handspringjoint)
                {
                    Destroy(handspringjoint);
                }
                if (objectspringjoint)
                {
                    Destroy(objectspringjoint);
                }

            }
           if(grabbing && (!handspringjoint && !objectspringjoint))
            {
                playercontroller.isLeftArmUp = false;
            }

        }
        else
        {
            if (!playercontroller.isRightArmUp)
            {
                grabbing = false;

                if (handspringjoint)
                {
                    Destroy(handspringjoint);
                }
                if (objectspringjoint)
                {
                    Destroy(objectspringjoint);
                }

            }
            if (grabbing && (!handspringjoint && !objectspringjoint))
            {
                playercontroller.isRightArmUp = false;
            }

        }
            



    }

    private void OnCollisionStay(Collision collision)
    {

        //check if locked first or broken
        //if()

      


        if (!RightHand && playercontroller.isLeftArmUp)
        {
            if (movablemask == (movablemask | (1 << collision.gameObject.layer)) && !handspringjoint)
            {
                grabbing = true;
                handspringjoint = this.gameObject.AddComponent<SpringJoint>();
                handspringjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                handspringjoint.breakForce = 100;
                handspringjoint.breakTorque = 100;
                handspringjoint.spring = 100;
            }
            if (unmovable == (unmovable | (1 << collision.gameObject.layer)) && !objectspringjoint)
            {
               
                grabbing = true;

                objectspringjoint = collision.gameObject.AddComponent<HingeJoint>();
                objectspringjoint.connectedBody = this.transform.parent.GetComponent<Rigidbody>();
                objectspringjoint.breakForce = 90000;
                objectspringjoint.breakTorque = 90000;
                
            }
            if (charactermask == (charactermask | (1 << collision.gameObject.layer)) && !handspringjoint)
            {
                //put sounds
                Debug.Log("grab");
                grabbing = true;
                handspringjoint = this.gameObject.AddComponent<SpringJoint>();
                handspringjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                handspringjoint.breakForce = 500;
                handspringjoint.breakTorque = 500;
                handspringjoint.spring = 500;
                handspringjoint.massScale = 0.25f;
            }

        }

        if (RightHand && playercontroller.isRightArmUp)
        {
            if (movablemask == (movablemask | (1 << collision.gameObject.layer)) && !handspringjoint)
            {
                grabbing = true;
                handspringjoint = this.gameObject.AddComponent<SpringJoint>();
                handspringjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                handspringjoint.breakForce = 100;
                handspringjoint.breakTorque = 100;
                handspringjoint.spring = 100;

            }
            if (unmovable == (unmovable | (1 << collision.gameObject.layer)) && !objectspringjoint)
            {
                grabbing = true;

                objectspringjoint = collision.gameObject.AddComponent<HingeJoint>();
                objectspringjoint.connectedBody = this.transform.parent.GetComponent<Rigidbody>();
                objectspringjoint.breakForce = 90000;
                objectspringjoint.breakTorque = 90000;

            }
            if (charactermask == (charactermask | (1 << collision.gameObject.layer)) && !handspringjoint)
            {
                //put sounds
                Debug.Log("grab");
                grabbing = true;
                handspringjoint = this.gameObject.AddComponent<SpringJoint>();
                handspringjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                handspringjoint.breakForce = 500;
                handspringjoint.breakTorque = 500;
                handspringjoint.spring = 500;
                handspringjoint.massScale = 0.25f;
            }

        }



    }
}