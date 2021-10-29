using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public GameObject machine;
    // Start is called before the first frame update
    void Start()
    {
        machine = GameObject.Find("Lift");

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        machine.GetComponent<LiftMove>().activator = true;

    }
    private void OnCollisionStay(Collision collision)
    {
        machine.GetComponent<LiftMove>().activator = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        machine.GetComponent<LiftMove>().activator = false;
    }
}
