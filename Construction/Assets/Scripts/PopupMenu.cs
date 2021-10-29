using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMenu : MonoBehaviour
{
    
    public Canvas ControlsMenu;// public variable which has the popup menu assigned in the inspector
    public bool ActiveMenu = false;//boolean set to false so the canvas isn't appearing in runtime 
    public void MenuPopup()//This function handles the popup menu process. 
    {
        if (ActiveMenu == false)/*if the button is clicked when the canvas is not active, then the active menu will become true and
                                 * the canvas will be enabled */
        {
            ActiveMenu = true;
            ControlsMenu.enabled = true;
        }
        else if (ActiveMenu == true)/*if the user presses the controls button or close button in the popup menu, then the 
                                     * Active menu is set to false and the popup menu is disabled*/
        {
            ActiveMenu = false;
            ControlsMenu.enabled = false;

        }
    }
}
