using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This class controlls the ball behavior */
public class Ball : MonoBehaviour
{
    public float maxVelocity = 10f;
    private bool trigger  = false; // when ball hits a special object, turn this to true
    private Rigidbody2D rb;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
    
        // look for the "Brick" tag that was assigned to the Apple GameObject prefab
        // Destroy bricks when the balls hits them 
        if (collidedWith.CompareTag("Brick"))
        {
            Debug.Log(collidedWith.name);
            // turn on trigger feature when adding items 
            Destroy(collidedWith);
        }

        if (collidedWith.CompareTag("Star"))
        {
            trigger = true;
        }
       
    }
}
