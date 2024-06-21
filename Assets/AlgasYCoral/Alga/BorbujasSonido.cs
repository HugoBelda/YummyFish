using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorbujasSonido : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }



    void Update()
    {
    }
    void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
