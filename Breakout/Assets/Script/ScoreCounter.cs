using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    public int score = 0; 
    //private Text uiText;
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        gt.text = "SCORE: " + score.ToString("#,0");
    }
}
