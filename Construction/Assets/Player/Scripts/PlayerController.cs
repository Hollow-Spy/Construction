using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float SpeedStrengh;
    [SerializeField] float ArmStrengh;
    [SerializeField] float jumpforce;
    public int targetfps;
    public bool Vysync;
    public Rigidbody torso;
    public GameObject Rig;
    public Animator animator;
    [SerializeField] public float armreach;

    public ConfigurableJoint Leftupperarm,Rightupperarm;

    [SerializeField] bool isPlayer1;

    public static bool Player1canJump,Player2canJump;
    public bool ragdolled;
    public bool isLeftArmUp, isRightArmUp;
     bool leftlocked,rightlocked;

    float armheight=.5f;


    JointDrive newarmstrengh;
  

    JointDrive OGnewarmstrengh;

    private void OnDestroy()
    {
        if(isPlayer1)
        {
            CheckpointManager.isPlayer1Alive = false;
           
        }else
        {
            CheckpointManager.isPlayer2Alive = false;

        }
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Respawn");
    }


    void Awake()
    {
        OGnewarmstrengh = Leftupperarm.angularXDrive;
       

        
        newarmstrengh.maximumForce = Leftupperarm.angularXDrive.maximumForce ;
        newarmstrengh.positionSpring = ArmStrengh;
      
        int vsyncNum;
        if(Vysync)
        {
            vsyncNum = 1;
        }
        else
        {
            vsyncNum = 0;
        }
       QualitySettings.vSyncCount = vsyncNum;
        if(targetfps > 0)
        {
            Application.targetFrameRate = targetfps;

        }
    }

    public void RagdollPlayer()
    {
    
            if (ragdolled == true)
            {
          
                ragdolled = false;
            }
            else
            {
                ragdolled = true;

            }

        isRightArmUp = false;
        isLeftArmUp = false;

        CopyLimb[] limbs = transform.GetComponentsInChildren<CopyLimb>();
            for (int i = 0; i < limbs.Length; i++)
            {
                limbs[i].Ragdoll();
            }
        

       
    }

    public void MoveArmUp(int armnum)
    {
        switch(armnum)
        {
            case 1:
                if(isRightArmUp)
                {
                    isRightArmUp = false;
                }
                else
                {
                    isRightArmUp = true;

                }
                break;
            case 0:
                if (isLeftArmUp)
                {
                    isLeftArmUp = false;
                }
                else
                {
                    isLeftArmUp = true;

                }
                break;
        }



       /* switch(armnum)
        {
            case 1:
             //   if(!rightlocked)
             //   {
             
                    isRightArmUp = true;
                 //   rightlocked = true;
            //    }
                
                RightArm.position = Vector3.MoveTowards(RightArm.position , PullPos.position, ArmStrengh * Time.deltaTime) ;
                rightspring.spring = 10;
                break;
            case 0:
            //    if(!leftlocked)
              //  {
                    isLeftArmUp = true;
                  //  leftlocked = true;
              //  }
                LeftArm.position = Vector3.MoveTowards(LeftArm.position, PullPos.position, ArmStrengh * Time.deltaTime);
                leftspring.spring = 10;

                break;
           

        }
       */
    }





    public void Jump()
    {
        if(Player1canJump && Player2canJump)
        {
            torso.AddForce(transform.up * jumpforce, ForceMode.Impulse);    
        }
    }

    public void MoveArmDown(int armnum)
    {
        Quaternion quart = new Quaternion(0, 0, 0, 1);
        switch (armnum)
        {
            case 1:
                Rightupperarm.angularXDrive = OGnewarmstrengh;
                Rightupperarm.angularYZDrive = OGnewarmstrengh;

                Rightupperarm.targetRotation = quart;
              
                rightlocked = false;
                //rightspring.spring = 0;

                break;
            case 0:
                Leftupperarm.angularXDrive = OGnewarmstrengh;
                Leftupperarm.angularYZDrive = OGnewarmstrengh;

                Leftupperarm.targetRotation = quart;
              
            
                leftlocked = false;

                //leftspring.spring = 0;

                break;
          


        }
    }
   

    public void ArmMovement()
    {
       

        if (isLeftArmUp)
        {
            
            
            Quaternion quart = new Quaternion(0, 0, armheight, 1);

            Leftupperarm.angularXDrive = newarmstrengh;
            Leftupperarm.angularYZDrive = newarmstrengh;

            Leftupperarm.targetRotation = quart;

           
        }
        else
        {
            MoveArmDown(0);
        }

        if (isRightArmUp)
        {

            Rightupperarm.angularXDrive = newarmstrengh;
            Rightupperarm.angularYZDrive = newarmstrengh;

            Quaternion quart = new Quaternion(0, 0, -armheight, 1);

            Rightupperarm.targetRotation = quart;



        }
        else
        {
            MoveArmDown(1);
        }


    }




    public void MoveCharacter(float horizontal, float vertical)
    {

        if (vertical != 0)
        {
       
            if (vertical > 0 && armheight >= -armreach)
            {
                armheight -= 2 *Time.deltaTime;
            }
            else
            {
                if (vertical < 0 && armheight <= armreach)
                {
                    armheight += 2 * Time.deltaTime;

                }
            }

        }


        if (horizontal == 0)
        {
            animator.SetBool("run", false);
            return;
        }

            
    
        animator.SetBool("run", true);

        torso.AddForce(transform.forward * SpeedStrengh * horizontal, ForceMode.Force);

    }

}
