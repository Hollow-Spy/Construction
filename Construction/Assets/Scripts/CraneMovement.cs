using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    public Transform pivot;
    public bool activator; 
    Vector3 origin;
    Vector3 rotated;
    // Start is called before the first frame update
    void Start()
    {
    origin = gameObject.transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
       rotated = gameObject.transform.rotation.eulerAngles;

       
        if (activator == true)
        {    
            if (rotated[2]>300f)
       {
            transform.RotateAround(pivot.position, Vector3.back, 15 * Time.deltaTime);
        }

       } 
       else if (rotated[2] < origin[2])
            transform.RotateAround(pivot.position, Vector3.forward, 15 * Time.deltaTime);
   //    Debug.LogError(rotated[2]);
    }
}
