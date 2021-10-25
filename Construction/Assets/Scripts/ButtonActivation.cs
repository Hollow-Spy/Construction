using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameObject machine;
    // Start is called before the first frame update
    void Start()
    {
         machine = GameObject.Find("Crane Pivot");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) 
    {
        machine.GetComponent<CraneMovement>().activator = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        machine.GetComponent<CraneMovement>().activator = false;
    }
    
}
