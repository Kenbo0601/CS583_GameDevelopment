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
    private int numOfBricks;
    
    
    /* game objects */
    public GameObject ball;
    public GameObject blueBrickPrefab;
    public GameObject redBrickPrefab;
    public GameObject greenBrickPrefab;
    public GameObject yellowBrickPrefab;
    public GameObject purpleBrickPrefab;
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
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score); // invoke HighScore.cs for updating high score 

            // handles bricks counter
            numOfBricks--; 
            Debug.Log(numOfBricks);
            Ball.hitFlag = false;

            if (numOfBricks <= 0)
            {
                GameClear.score = timeCounter.elapsedTime;
                Debug.Log("Game Clear!");
                SceneManager.LoadScene("GameClear");
            }
        }
    }
    
    
    // Update the best time 
    private void FixedUpdate()
    { 
        BestTime.TRY_SET_BEST_TIME(timeCounter.elapsedTime); 
    }
   
    
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
            
            GameObject blueBrickTwo = Instantiate(blueBrickPrefab, transform);
            GameObject redBrickTwo = Instantiate(redBrickPrefab, transform);
            GameObject greenBrickTwo = Instantiate(greenBrickPrefab, transform);
            GameObject yellowBrickTwo = Instantiate(yellowBrickPrefab, transform);
            GameObject purpleBrickTwo = Instantiate(purpleBrickPrefab, transform);
                        
            
            // set position for each brick - under the Hitter
            blueBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos, 0);
            redBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+2, 0);
            greenBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+4, 0);
            yellowBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+6, 0);
            purpleBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+8, 0);
            
            // set position for each brick - above the Hitter
            blueBrickTwo.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+24, 0);
            redBrickTwo.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+22, 0);
            greenBrickTwo.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+20, 0);
            yellowBrickTwo.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+18, 0);
            purpleBrickTwo.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+16, 0);
                                                                         
            
            // add bricks into a list
            brickList.Add(blueBrick);
            brickList.Add(redBrick);
            brickList.Add(greenBrick);
            brickList.Add(yellowBrick);
            brickList.Add(purpleBrick);
            brickList.Add(blueBrickTwo);
            brickList.Add(redBrickTwo);
            brickList.Add(greenBrickTwo);
            brickList.Add(yellowBrickTwo);
            brickList.Add(purpleBrickTwo);
        } 
        
        numOfBricks = brickList.Count; // assign the total number of bricks to this variable 
        Debug.Log("num of bricks at the beginning of the game: " + numOfBricks);
    }

    private void GenerateStar()
    {
        // create a star object in the game
        GameObject star = Instantiate(starPrefab);
        star.transform.position = new Vector3(58, 31, 0); // place the star on the right top corner 
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
