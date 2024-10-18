using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This class controlls the ball behavior */
public class Ball : MonoBehaviour
{
    public float maxVelocity = 10f; // max speed of the ball 
    private bool trigger; // when ball hits a special object, turn this to true
    private Rigidbody2D rb; 
    
    /* Audio */
    public AudioSource audioSource; 
    
    /* ScoreCounter Object */
    public ScoreCounter scoreCounter;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trigger = false;
        
        // check if AudioSource is assigned in the Ispector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Find scoreCounter obj in the Hierarchy
        scoreCounter = scoreGO.GetComponent<ScoreCounter>(); // get the scoreCounter script component of scoreGO
    }

    // Update is called once per frame
    void Update()
    {
        // if ball hits a special object, increase the size
        if (trigger)
        {
            transform.localScale = new Vector3(2.5f,2.5f,0);
        }
        else if (!trigger) // if trigger is false, resize the ball to original
        {
            transform.localScale = new Vector3(1.2f,1.2f,0);
        }
        //Debug.Log(rb.velocity.magnitude);
        // make sure ball speed won't exceed max velocity 
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        BallBounceSound(); // play ball bounce sound when collision occurs
        
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
    
        // look for the "Brick" tag that was assigned to the Apple GameObject prefab
        // Destroy bricks when the balls hits them 
        if (collidedWith.CompareTag("Brick"))
        {
            Destroy(collidedWith); // destroy brick
            scoreCounter.score += 100; // increment the score 
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score); // invoke HighScore.cs for updating high score 
        }

        if (collidedWith.CompareTag("Star"))
        {
            Destroy(collidedWith); // destroy star
            trigger = true; // turn on flag to make the ball bigger
        }
    }
    
    // this function gets called everytime the ball hits an object
    public void BallBounceSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
