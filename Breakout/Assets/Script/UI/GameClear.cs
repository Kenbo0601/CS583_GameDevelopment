using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear : MonoBehaviour
{
    public static float score;
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        Debug.Log(score); 
        // convert the elapsed time to minutes and seconds
        int min = Mathf.FloorToInt(score / 60F);
        int sec = Mathf.FloorToInt(score % 60F);
        int milliSec = Mathf.FloorToInt((score * 100F) % 100F);
            
        gt.text = "YOUR TIME: " + $"{min:D2}:{sec:D2}:{milliSec:D2}";
    }

    void Update()
    {
        
    }
}
