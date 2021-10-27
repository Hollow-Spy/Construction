using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallscript : MonoBehaviour
{
    [SerializeField] float minweight;
    public GameObject wall,brokenwall,particles;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>().mass > minweight)
        {
            wall.SetActive(false);
            particles.SetActive(true);
            brokenwall.SetActive(true);
        }
    }
}
