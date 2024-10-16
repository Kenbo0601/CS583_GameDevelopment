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
        
        // Play background music 
        if (audioSource != null && audioSource.clip != null)
        {
            // static variable "AudioMuted" in StartEnd.cs is being passed here for mute control
            audioSource.mute = StartScreen.AudioMuted; 
            audioSource.Play();
        } 
    }

    void Update()
    {
        
    }
}
