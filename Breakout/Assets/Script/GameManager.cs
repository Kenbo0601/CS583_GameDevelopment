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
    
    /* game objects */
    public GameObject ball;
    public GameObject blueBrickPrefab;
    public GameObject redBrickPrefab;
    public GameObject greenBrickPrefab;
    public GameObject yellowBrickPrefab;
    public GameObject starPrefab;
    
    /* Audio */
    public AudioSource audioSource; // background music
    
    
    private void Awake()
    {
        ball = GameObject.Find("Ball");
        
        // create a star object in the game
        GameObject star = Instantiate(starPrefab);
        star.transform.position = new Vector3(58, 31, 0); // place the star on the right top corner
        
        // Instantiate bricks  
        for (int i = 0; i < size.x; i++)
        {
            GameObject blueBrick = Instantiate(blueBrickPrefab, transform);
            GameObject redBrick = Instantiate(redBrickPrefab, transform);
            GameObject greenBrick = Instantiate(greenBrickPrefab, transform);
            GameObject yellowBrick = Instantiate(yellowBrickPrefab, transform);
            blueBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos, 0);
            redBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+2, 0);
            greenBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+4, 0);
            yellowBrick.transform.position = transform.position + new Vector3((i-startPos) * offset.x, bottomPos+6, 0);
        }
    }
    
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < bottomScreenPos)
        {
            SceneManager.LoadScene("GameOver"); // If ball falls out, move to gameover screen 
        }
    }
}
