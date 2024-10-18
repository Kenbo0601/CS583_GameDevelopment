using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    public float eplapsedTime = 0f;
    private bool isCounting = false;
    //private Text uiText;
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            eplapsedTime += Time.deltaTime; // add the time since the last frame to the elapsed time 
        
            // convert the elapsed time to minutes and seconds
            int min = Mathf.FloorToInt(eplapsedTime / 60F);
            int sec = Mathf.FloorToInt(eplapsedTime % 60F);
            int milliSec = Mathf.FloorToInt((eplapsedTime * 100F) % 100F);
        
            gt.text = "TIME: " + $"{min:D2}:{sec:D2}:{milliSec:D2}"; // display the current elapsed time
        }
    } 
}
