using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wreckingball : MonoBehaviour
{

  
    

   public void Activate()
    {
    
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
    }
}
