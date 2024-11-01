using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    /* Audio */
    public AudioSource audioSource; // background music
    
    void Start()
    {
        // check if the audiosource is assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        AudioUtils.PlaySound(audioSource); // call Audio Utility class function 
    }
}
