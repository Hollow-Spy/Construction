using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask characterMask;
    public GameObject nailhit;

void OnCollisionEnter(Collision collision)
     {
        if ( characterMask == (characterMask | (1 << collision.gameObject.layer)) && collision.gameObject.GetComponent<ConfigurableJoint>() )
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Impulse);
            GameObject nail = Instantiate(nailhit, collision.contacts[0].point, Quaternion.Euler(0,0,Random.Range(-90,90)));
            nail.SendMessage("deflate", collision.gameObject);
        }
       

         Destroy(gameObject);
     }


}