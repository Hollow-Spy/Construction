using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollector : MonoBehaviour
{

    public PlayerController controller;

    float Horizontal;
    float Vertical;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Horizontal = 1;

        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Horizontal = 0;

        }

        if(Input.GetKey(KeyCode.W))
        {
            Vertical = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vertical = -1;
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            Vertical = 0;
        }

        if(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E) )
        {
            controller.MoveArmUp(2);
        }
        else
        {
            if(Input.GetKey(KeyCode.Q))
            {
                controller.MoveArmUp(1);

            }
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("up");

                controller.MoveArmUp(0);

            }

        }
        
        if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            controller.MoveArmDown(2);
        }
        else
        {
            if (!Input.GetKey(KeyCode.Q))
            {
                controller.MoveArmDown(1);

            }
            if (!Input.GetKey(KeyCode.E))
            {
                controller.MoveArmDown(0);

            }

        }

        controller.MoveCharacter(Horizontal, Vertical);
    }

  

}
