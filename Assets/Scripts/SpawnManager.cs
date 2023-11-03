using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of the spawnManager and 
 * spawns obsacles in front of the player periodically.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private PlayerController playerControllerScript;
    private Vector3 spawnPos;
    private float startDelay, repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(25, 0, 0);
        startDelay = 5.0f;
        repeatRate = 2.0f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        
    }

    private void SpawnObstacle()
    {
        if(!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        else
        {
            CancelInvoke();
        }
        
    }
}
