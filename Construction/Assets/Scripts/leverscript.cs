using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverscript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.centerOfMass = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
