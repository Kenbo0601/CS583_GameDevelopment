using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        // find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input 
        Vector3 mousePos2D = Input.mousePosition;
        
        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;
        
        // Convert the point from 2D screen space into 3D game world space 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        // Move the x position of this basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
    
        // look for the "Apple" tag that was assigned to the Apple GameObject prefab
        if (collidedWith.CompareTag("Apple"))
        {
            Debug.Log(collidedWith.name);
            scoreCounter.score += 100;
            Destroy(collidedWith);
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        else if (collidedWith.CompareTag("BadApple"))
        {
            Destroy(collidedWith);
            scoreCounter.score -= 200;
            
        }
    }
}
