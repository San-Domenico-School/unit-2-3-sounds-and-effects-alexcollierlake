using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**********
 * 
 * This script is a component of the player and controls
 * the movement based on player input
 * 
 * October 17, 2023
 * Alexandra Collier-Lake
 * 
 ***********/


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;

    private Animator playerAnimator;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    public bool gameOver { get; private set; }
    private AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        gameAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump(InputValue input)
    {
        if(isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            gameAudio.Play();

        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ground")
        {
            isOnGround = true;

        }
        else if (col.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);

        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        //
       
    }
}
