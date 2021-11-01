using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed = 7f;

    private bool isAtStartPos;
    private bool isAtEndPos;

    // Start is called before the first frame update
    void Start()
    {
        // go to start pos?
        Debug.Log("going to start");
        transform.position = startPos.position;
        //transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, Time.deltaTime * speed);

    }

    // Update is called once per frame
    void Update()
    {
        // use bools to determin which to go?

        if (transform.position == startPos.position)
        {
            Debug.Log("going to end");
            isAtStartPos = true;
            isAtEndPos = false;
        }
        else if (transform.position == endPos.position)
        {
            Debug.Log("going to start");
            isAtEndPos = true;
            isAtStartPos = false;
        }

        if (isAtStartPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, Time.deltaTime * speed);
        }
        else if (isAtEndPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, Time.deltaTime * speed);
        }


    }
}
