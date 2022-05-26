using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    [SerializeField] Vector3 RotationReset;
   
    public void resetRot()
    {
        transform.localEulerAngles = new Vector3(RotationReset.x, RotationReset.y, RotationReset.z);

    }
}
