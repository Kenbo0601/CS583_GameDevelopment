using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Inscribed")] 
    public Vector2Int size; // size.x = num of bricks in x direction
    public Vector2 offset; // offset between bricks
    public int startPos = -6; // left most position of bricks
    public int bottomPos = -2; // the bottom most bricks positions for Y
    public int bottomScreenPos = -33; // bottom screen position
    private List<GameObject> brickList; // store bricks 
    private int numOfBricks; // integer variable for keeping track of the number of bricks
    
    
    /* game objects */
    public GameObject ball;
    public GameObject blueBrickPrefab;
    public GameObject redBrickPrefab;
    public GameObject greenBrickPrefab;
    public GameObject yellowBrickPrefab;
    public GameObject purpleBrickPrefab;
    public GameObject blueSquareBrickPrefab;
    public GameObject starPrefab;
    
    /* Audio */
    public AudioSource audioSource; // background music
    
    /* Score and Time Objects */
    public ScoreCounter scoreCounter;
    public TimeCounter timeCounter; // keeps track of the time in the game
    
    
    void Start()
    {
        ball = GameObject.Find("Ball"); // find ball object for keeping track of the ball location 
        
        GenerateStar(); 
        GenerateBricks(); // function call for generating bricks at the beginning of the game
        AudioController(); 
        GenerateTime();
        GenerateScore();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < bottomScreenPos)
        {
            SceneManager.LoadScene("GameOver"); // If ball falls out, move to gameover screen 
        }
        
        // if ball hits a brick, hitFlag turns true so we decrement the count from bricklist
        if (Ball.hitFlag)
        {
            // handles score  
            scoreCounter.score += 100; // increment the score 
           
            // handles bricks counter
            numOfBricks--; 
            Debug.Log(numOfBricks);
            Ball.hitFlag = false;

            if (numOfBricks <= 0)
            {
                GameClear.score = timeCounter.elapsedTime;
                BestTime.TRY_SET_BEST_TIME(GameClear.score); // invoke BestTime.cs for updating best time 
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score); // invoke HighScore.cs for updating high score
                SceneManager.LoadScene("GameClear");
            }
        }
        
        // if ball hits enemy, decrese score by 800
        if (Ball.enemyFlag)
        {
            scoreCounter.score -= 500;
            Ball.enemyFlag = false;
        }
    }
    
    // Update the best time 
    /*private void FixedUpdate()
    { 
        BestTime.TRY_SET_BEST_TIME(timeCounter.elapsedTime); 
    }*/
   
    
    // generate bricks in the game, and store them into a list
    private void GenerateBricks()
    {
        brickList = new List<GameObject>(); // instantiate a list that holds bricks 
        
        // Instantiate bricks  
        for (int i = 0; i < size.x; i++)
        {
            // create brick objects for each color 
            GameObject blueBrick = Instantiate(blueBrickPrefab, transform);
            GameObject redBrick = Instantiate(redBrickPrefab, transform);
            GameObject greenBrick = Instantiate(greenBrickPrefab, transform);
            GameObject yellowBrick = Instantiate(yellowBrickPrefab, transform);
            GameObject purpleBrick = Instantiate(purpleBrickPrefab, transform);
            GameObject blueSquareBrick = Instantiate(blueSquareBrickPrefab, transform);
            
            // set position for each brick - under the Hitter
            blueBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos, 0);
            redBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+2, 0);
            greenBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+4, 0);
            yellowBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+6, 0);
            purpleBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+8, 0);
            blueSquareBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+20, 0);
            
            // add bricks into a list
            brickList.Add(blueBrick);
            brickList.Add(redBrick);
            brickList.Add(greenBrick);
            brickList.Add(yellowBrick);
            brickList.Add(purpleBrick);
            brickList.Add(blueSquareBrick);
        } 
        
        numOfBricks = brickList.Count; // assign the total number of bricks to this variable 
        Debug.Log("num of bricks at the beginning of the game: " + numOfBricks);
    }

    private void GenerateStar()
    {
        // create star objects in the game
        GameObject starRight = Instantiate(starPrefab);
        GameObject starLeft = Instantiate(starPrefab);
         
        starRight.transform.position = new Vector3(58, 31, 0); // place the star on the right top corner 
        starLeft.transform.position = new Vector3(-58, 20, 0); // place the star on the left, above the leftPaddle
    }

    private void AudioController()
    {
        // check if the audiosource is assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        // Play background music 
        if (audioSource != null && audioSource.clip != null)
        {
            // static variable "AudioMuted" in StartEnd.cs is being passed here for mute control
            audioSource.mute = StartScreen.AudioMuted; 
            audioSource.loop = true; // set loop to true so it plays forever 
            audioSource.Play();
        } 
    }

    private void GenerateTime()
    {
        GameObject timeGO = GameObject.Find("TimeCounter"); // Find scoreCounter obj in the Hierarchy
        timeCounter = timeGO.GetComponent<TimeCounter>(); // get the scoreCounter script component of scoreGO 
    }

    private void GenerateScore()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Find scoreCounter obj in the Hierarchy
        scoreCounter = scoreGO.GetComponent<ScoreCounter>(); // get the scoreCounter script component of scoreGO
    }
}
