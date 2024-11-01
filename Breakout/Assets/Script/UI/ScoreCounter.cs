using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    public int score = 0; 
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
    }
    
    // Display the score on the game play screen 
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        gt.text = "SCORE: " + score.ToString("#,0");
    }
}
