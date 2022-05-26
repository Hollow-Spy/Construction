using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] Transform Position1,Position2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            CheckpointManager.spawnpoint = Position1.position;
            CheckpointManager.spawnpoint2 = Position2.position;
            Destroy(gameObject);
        }
    }
}
