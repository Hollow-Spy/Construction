using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderUp : MonoBehaviour
{
    public SpringJoint ladderspring;
    public GameObject ladder;
    [SerializeField] float climbspeed;
    bool activate;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == ladder)
        {
            activate = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(!ladderspring && activate && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * climbspeed, ForceMode.Impulse);
        }
    }

 
}
