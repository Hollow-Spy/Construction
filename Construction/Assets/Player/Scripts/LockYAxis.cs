using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockYAxis : MonoBehaviour
{
    float y;
    void Start()
    {
        y = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
}
