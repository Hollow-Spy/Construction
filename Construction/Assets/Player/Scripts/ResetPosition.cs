using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 PositionReset;
    public void resetPos()
    {
        transform.localPosition = new Vector3(PositionReset.x, PositionReset.y, PositionReset.z);

    }
}
