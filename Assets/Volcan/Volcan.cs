using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcan : MonoBehaviour
{
    public GameObject Lava;
    public float TiempoActiva;
    public float TiempoInactivo;

    private AudioSource audioSource;
    public AudioClip erupcion;
    public Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(Actividad());
        
    }

    IEnumerator Actividad()
    {

        Lava.SetActive(false);
        yield return new WaitForSeconds(TiempoInactivo);

        Lava.SetActive(true);
        PlaySound(erupcion);
        animator.SetTrigger("isLava");

        yield return new WaitForSeconds(TiempoActiva);
        StartCoroutine(Actividad());
    }
    
    private void PlaySound(AudioClip clip)
    {
        if (IsSoundEffectsEnabled() && !audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    private bool IsSoundEffectsEnabled()
    {
        return PlayerPrefs.GetInt("SoundEffectsEnabled", 1) == 1;
    }
}
