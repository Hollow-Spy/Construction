using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static Vector3 spawnpoint;
    public GameObject player1, player2;
    public static bool isPlayer1Alive, isPlayer2Alive;

    public GameObject RespawnParticles;

    private void Awake()
    {
        spawnpoint = GameObject.Find("Player1").transform.position;
        isPlayer1Alive = true;
        isPlayer2Alive = true;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnNumerator());

    }
    IEnumerator RespawnNumerator()
    {
        yield return new WaitForSeconds(2);
        
        if(!isPlayer1Alive)
        {
            
            Instantiate(player1, spawnpoint, Quaternion.identity);
            isPlayer1Alive = true;
        }
        if(!isPlayer2Alive)
        {
            Instantiate(player2, spawnpoint, Quaternion.identity);
            isPlayer2Alive = true;
        }
        Instantiate(RespawnParticles, spawnpoint, RespawnParticles.transform.rotation);
    }

}
