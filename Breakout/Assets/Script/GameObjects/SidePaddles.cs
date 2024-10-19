using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePaddles : MonoBehaviour
{
    public float rotationSpeed = 140f;
    public BoxCollider2D boxCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider.enabled = false;
    }

    // Update is called once per frame
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
