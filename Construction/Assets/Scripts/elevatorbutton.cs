using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorbutton : MonoBehaviour
{
    public int numberButtons;
    public static int pressedbuttons;
    [SerializeField]bool mainbutton;
    public GameObject target;

    bool pressed;
    private void Start()
    {
        pressedbuttons = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(pressedbuttons);
        if(!pressed)
        {
            pressed = true;
            pressedbuttons++;
        }
        if(mainbutton && pressedbuttons >=numberButtons )
        {
           
            target.SendMessage("Activate");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(pressed)
        {
            pressed = false;
            pressedbuttons--;
        }
    }


}
