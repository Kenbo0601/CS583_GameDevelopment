using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility class for Audio 
public static class AudioUtils 
{
    public static void PlaySound(AudioSource audioSource)
    {
        // Play background music 
        if (audioSource != null && audioSource.clip != null)
        {
            // static variable "AudioMuted" in StartEnd.cs is being passed here for mute control
            audioSource.mute = StartScreen.AudioMuted; 
            audioSource.Play();
        }  
    }
}
