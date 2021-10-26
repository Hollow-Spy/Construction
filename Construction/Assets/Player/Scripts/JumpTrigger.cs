using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] bool player1;

    private void OnTriggerStay(Collider other)
    {
        if (player1)
        {
            PlayerController.Player1canJump = true;

        }
        else
        {
            PlayerController.Player2canJump = true;

        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (player1)
        {
            PlayerController.Player1canJump = false;
        }
        else
        {
            PlayerController.Player2canJump = false;

        }
    }
}
