using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear : MonoBehaviour
{
    public static float score;
    private TextMeshProUGUI gt;
    
    /* Audio */
    public AudioSource audioSource; // background music
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        gt.text = "YOUR TIME: " + TimeConversionUtils.ConvertTime(score);
       
        // check if the audiosource is assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        AudioUtils.PlaySound(audioSource); // call Audio Utility class function 
    }
}
