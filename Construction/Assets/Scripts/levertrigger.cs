using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levertrigger : MonoBehaviour
{
    public Rigidbody lever;
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == lever.gameObject)
        {
            target.SendMessage("Activate");
        }
    }
}
