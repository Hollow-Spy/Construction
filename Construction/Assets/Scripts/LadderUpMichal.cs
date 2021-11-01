using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderUpMichal : MonoBehaviour
{

    public float climbspeed = 10;



    private void OnTriggerStay(Collider other)
    {

            other.GetComponent<Rigidbody>().AddForce(Vector3.up * climbspeed, ForceMode.Impulse);
        
    }
}
