using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float SpeedStrengh;
    [SerializeField] float rotationStrengh;
    public int targetfps;
    public bool Vysync;
    public Rigidbody torso;
    public GameObject Rig;
    public Animator animator;


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
