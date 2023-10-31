using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of backround and the obstacles,
 * and moves them left to simulate the player running.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class MoveLeft : MonoBehaviour
{
    private float speed, leftBound;
    private PlayerController playerControllerScript;

    [SerializeField] private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15.0f;
        leftBound = -15.0f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        destroyOutOfScene();

        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Time.deltaTime * speed * direction);
        }
        else
        {
            speed = 0.0f;
        }
        
    }

    private void destroyOutOfScene()
    {
        if(gameObject.transform.position.x < leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

}
