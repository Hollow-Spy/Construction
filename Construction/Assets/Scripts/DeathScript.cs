using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject particles;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(particles, other.transform.position, particles.transform.rotation);
            if (other.gameObject.layer == 8)
            {
                Destroy(GameObject.Find("Player2"));
            }
            else
            {
                Destroy(GameObject.Find("Player1"));

            }
          
        }
    }
}
