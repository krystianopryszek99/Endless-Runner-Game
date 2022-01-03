using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for background music
public class MusicPlayer : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 1f;

    // play the music on start
    void Start()
    {
        AudioSource.Play();
    }

    // update the volume when using the slider in the options menu
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
