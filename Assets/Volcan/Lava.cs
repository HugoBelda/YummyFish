using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public bool JugadorEnArea;
    public Vida VidaPersonaje;
    public float tiempoEnLava;

    private AudioSource audioSource;
    public AudioClip danioLava;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        VidaPersonaje = FindObjectOfType<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (JugadorEnArea == true)
        {
            tiempoEnLava += Time.deltaTime;
            if (tiempoEnLava > 3)
            {
                tiempoEnLava = 0;
                VidaPersonaje.TakeDamage(1);
            }
        }
        else
        {
            tiempoEnLava = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JugadorEnArea = true;
            VidaPersonaje.TakeDamage(1);
            PlaySound(danioLava);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JugadorEnArea = false;
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip; // Asigna el clip correspondiente

            audioSource.Play();
        }
    }
}