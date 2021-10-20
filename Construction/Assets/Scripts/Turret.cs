using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public GameObject nailPrefab;
    public Rigidbody rb;
    public float speed = 20f;
    
    


     void Start()
     {
        StartCoroutine(fireRate());
     }

    IEnumerator fireRate()
     {   
        yield return new WaitForSeconds(5f);
        Shoot();
        Debug.Log("Shot Fired");
        StartCoroutine(fireRate());
    }




    void Shoot()
    {
       Instantiate(nailPrefab, firePoint.position, firePoint.rotation);
       nailPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
       


    }



















}
