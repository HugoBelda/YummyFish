
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEscenas : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StopAllMusic();

        audioSource.Play();
    }

    void StopAllMusic()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in allAudioSources)
        {
            if (source != audioSource)
            {
                source.Stop();
            }
        }
    }

    void Update()
    {
        
    }
}