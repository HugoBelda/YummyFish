using UnityEngine;

public class SonidoComer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip soundEnemy1; // Sonido para el primer tipo de enemigo
    public AudioClip soundEnemy2; // Sonido para el segundo tipo de enemigo
    public AudioClip soundEnemy3; // Sonido para el segundo tipo de enemigo
    public AudioClip soundEnemy4; // Sonido para el segundo tipo de enemigo

    public AudioClip soundDamage1; // Sonido para el daño
    public AudioClip soundDamage2; // Sonido para el daño
    public AudioClip soundEnterCoralMarron; // Sonido para el daño
    public AudioClip soundEnterCoralRojo; // Sonido para el daño
    public AudioClip soundEnterCoralMorado; // Sonido para el daño

    PlayerController playerController;
    private CoralNormal coralNormal;
    private CoralRojo coralRojo;
    private CoralMorado coralMorado;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
        coralNormal = FindObjectOfType<CoralNormal>();
        coralRojo = FindObjectOfType<CoralRojo>();
        coralMorado = FindObjectOfType<CoralMorado>();

        // Inicializar el estado del componente basándose en la preferencia guardada
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            PlaySound(soundEnemy1);
        }
        else if (other.CompareTag("Predator"))
        {
            if (playerController != null)
            {
                if (playerController.PuedeComerMedianos)
                {
                    PlaySound(soundEnemy2);
                }
                else
                {
                    PlaySound(soundDamage1);
                }
            }
        }
        else if (other.CompareTag("PredatorGrande"))
        {
            if (playerController != null)
            {
                if (playerController.PuedeComerGrandes)
                {
                    PlaySound(soundEnemy3);
                }
                else
                {
                    PlaySound(soundDamage2);
                }
            }
        }
        else if (other.CompareTag("PezGlobo"))
        {
            PlaySound(soundEnemy4);
        }
        else if (other.CompareTag("coralMarron"))
        {
            if (coralNormal != null)
            {

                if (!coralNormal.coralDesactivado) // Verificar si el coral no está desactivado
                {
                    PlaySound(soundEnterCoralMarron);
                }
            }
        }
        else if (other.CompareTag("coralRojo"))
        {
            if (coralRojo != null)
            {

                if (!coralRojo.coralDesactivado) // Verificar si el coral no está desactivado
                {
                    PlaySound(soundEnterCoralRojo);
                }
            }

        }
        else if (other.CompareTag("coralMorado"))
        {
            if (coralMorado != null)
            {

                if (!coralMorado.coralDesactivado) // Verificar si el coral no está desactivado
                {
                    PlaySound(soundEnterCoralMorado);
                }
            }
        }
        }

        void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
