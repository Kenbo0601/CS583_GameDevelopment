using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    //Distance where Hitter turns around 
    public float leftAndRightEdge = 10f;
    
    // chance that the Hitter will change directions
    public float changeDirChance = 10f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos; 
        
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; // change direction
        }
    } 
}