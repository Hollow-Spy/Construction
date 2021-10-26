using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollector2 : MonoBehaviour
{
    public PlayerController controller;

    float Horizontal;
    float Vertical;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            controller.RagdollPlayer();
        }


        if(controller.ragdolled==false)
        {

      

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Horizontal = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Horizontal = 1;

        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            Horizontal = 0;

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vertical = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vertical = -1;
        }

        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            Vertical = 0;
        }



            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                controller.MoveArmUp(1);

            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                controller.MoveArmUp(0);

            }


            if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jump();
        }


        controller.MoveCharacter(Horizontal, Vertical);
            controller.ArmMovement();

        }




    }

}
