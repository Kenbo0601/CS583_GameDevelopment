using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    static private TextMeshProUGUI gt;
    static private int _SCORE = 1000;
    
    
    // Awake is a built-in function, gets called before Start()
    private void Awake()
    {
        gt = GetComponent<TextMeshProUGUI>();
        
        // If the PlayerPrefs HighScore already exists, read
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    // property field
    public static int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore",value);
            if (gt != null)
            {
                gt.text = "High Score: " + value.ToString();
            }
        }
    }

    public static void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if(scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }
}
