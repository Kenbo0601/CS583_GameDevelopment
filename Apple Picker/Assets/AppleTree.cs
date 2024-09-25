using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;


public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    
    // prefab for instantiating apples
    public GameObject applePrefab;
    
    // prefab for instantiating bad apples
    public GameObject badApplePrefab;
    
    //Speed at which the AppleTree moves
    public float speed = 1f;
    
    //Distance where AppleTree turns around 
    public float leftAndRightEdge = 10f;
    
    //Chance that the AppleTree will change directions 
    public float changeDirChance = 0.1f;
    
    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;
    
    // define a scoreCounter object
    public ScoreCounter scoreCounter;
    
    // how much to increase speed per second 
    public float speedIncreaseRate = 2f;
    
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
        // find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }
    
    // Creates an instance of applePrefab and assigns it to the local GameObject variable apple
    void DropApple()
    {
        //TODO
        // add random variable to mix up apple and bad apple drop
        int N = 5;  // Range [0, 5)
        int randomInt = Mathf.FloorToInt(Random.value * N);
        bool scoreFlag = false;
        GameObject apple;
        
        // 1/5 chances to get bad apple
        if (randomInt == 0)
        {
            apple = Instantiate<GameObject>(badApplePrefab);
        }
        else
        {
            apple = Instantiate<GameObject>(applePrefab);
        }
        
        apple.transform.position = transform.position;
        
        // increase speed after passing 1000 
        if (scoreCounter.score != 0 && scoreCounter.score % 1000 == 0)
        {
            scoreFlag = true;
            if (appleDropDelay - 0.02f > 0.4f && scoreFlag)  
            {
                appleDropDelay -= 0.02f;
                scoreFlag = false;
            }
        }
        
        //Debug.Log("drop delay: "+ appleDropDelay);
        
        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        // Increase speed over time
        // since the speed could be negative depending on the direction,
        // increase it only when speed is positive (moving right)
        if (speed > 0)
        {
            speed += speedIncreaseRate * Time.deltaTime * 6;
        }
        Debug.Log("current speed: " + speed);

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
        // Random direction changes are now time-based due to this function 
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change direction
        }
    }
}
