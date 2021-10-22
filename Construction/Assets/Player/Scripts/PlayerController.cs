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
    public Transform PullPos;
    public Transform LeftArm;
    public Transform RightArm;
    public SpringJoint rightspring,leftspring;

    public Transform OGRightArmPos, OGLeftArmPos;

    public static bool Player1canJump,Player2canJump;
     
    public bool isLeftArmUp, isRightArmUp;
     bool leftlocked,rightlocked;
    void Awake()
    {
      
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

    public void MoveArmUp(int armnum)
    {
        switch(armnum)
        {
            case 1:
                if(!rightlocked)
                {
                    isRightArmUp = true;
                    rightlocked = true;
                }
                RightArm.position = Vector3.MoveTowards(RightArm.position, PullPos.position, ArmStrengh * Time.deltaTime);
                rightspring.spring = 10;
                break;
            case 0:
                if(!leftlocked)
                {
                    isLeftArmUp = true;
                    leftlocked = true;
                }
                LeftArm.position = Vector3.MoveTowards(LeftArm.position, PullPos.position, ArmStrengh * Time.deltaTime);
                leftspring.spring = 10;

                break;
            case 2:
                if(!leftlocked)
                {
                    isLeftArmUp = true;
                    leftlocked = true;
                }
                if(!rightlocked)
                {
                    isRightArmUp = true;
                    rightlocked = true;
                }
               
                LeftArm.position = Vector3.MoveTowards(LeftArm.position, PullPos.position, ArmStrengh * Time.deltaTime);
                RightArm.position = Vector3.MoveTowards(RightArm.position, PullPos.position, ArmStrengh * Time.deltaTime);
                rightspring.spring = 10;
                leftspring.spring = 10;
                break;

        }

    }

    public void Jump()
    {
        if(Player1canJump && Player2canJump)
        {
            torso.AddForce(transform.up * jumpforce, ForceMode.Impulse)
;        }
    }

    public void MoveArmDown(int armnum)
    {
        switch (armnum)
        {
            case 1:
              
                RightArm.localPosition = Vector3.MoveTowards(RightArm.localPosition, OGRightArmPos.localPosition, ArmStrengh * Time.deltaTime);
                isRightArmUp = false;
                rightlocked = false;
                rightspring.spring = 0;

                break;
            case 0:
                LeftArm.localPosition = Vector3.MoveTowards(LeftArm.localPosition, OGLeftArmPos.localPosition, ArmStrengh * Time.deltaTime);
                isLeftArmUp = false;
                leftlocked = false;

                leftspring.spring = 0;

                break;
            case 2:
                rightlocked = false;
                leftlocked = false;

                LeftArm.localPosition = Vector3.MoveTowards(LeftArm.localPosition, OGLeftArmPos.localPosition, ArmStrengh * Time.deltaTime);
                RightArm.localPosition = Vector3.MoveTowards(RightArm.localPosition, OGRightArmPos.localPosition, ArmStrengh * Time.deltaTime);
                isLeftArmUp = false;
                isRightArmUp = false;

                leftspring.spring = 0;


                rightspring.spring = 0;
                break;

        }
    }
   
   

   public void MoveCharacter(float horizontal, float vertical)
    {
       

        if(horizontal == 0)
        {
            animator.SetBool("run", false);
            return;
        }
     
            
    
        animator.SetBool("run", true);

        torso.AddForce(transform.forward * SpeedStrengh * horizontal, ForceMode.Force);

    }

}
