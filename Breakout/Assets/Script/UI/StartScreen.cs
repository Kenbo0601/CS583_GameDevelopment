using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

// GameOver Scene
public class StartScreen : MonoBehaviour
{
    /* Audio */
    public AudioSource audioSource; // background music

    public static bool AudioMuted; // static variable for mute control
    
    void Start()
    {
        // check if the audiosource is assigned in the Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        AudioUtils.PlaySound(audioSource); 
    }

    // Handles audio check button 
    public void audioControl(bool isOn)
    {
        if (isOn)
        {
            audioSource.Play();
            AudioMuted = false;
        }
        else
        {
            audioSource.Stop();
            AudioMuted = true;
        }
    }

}
