using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class controls the paddles on the left and right side of the game screen 
public class SidePaddles : MonoBehaviour
{
    public float rotationSpeed = 140f;
    public BoxCollider2D boxCollider;
    
    void Start()
    {
        boxCollider.enabled = false;
    }

    void Update()
    {
        // rotation movement
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotationSpeed, 45) - 25);
        
        // turn on box collider when space key is hit
        if (boxCollider.enabled)
        {
            boxCollider.enabled = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            boxCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D ball)
    {
        Debug.Log("hi");
        boxCollider.enabled = false;
    }
}
