using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralNormal : MonoBehaviour
{
    private Vida vidaScript;
    public bool jugadorEnArea = false; // Cambiado a público para acceder desde otros scripts
    private Renderer[] coralRenderers;
    public bool coralDesactivado = false; // Variable para controlar si el coral ha sido desactivado

    public int cantidadVida = 1; // Modificado a 1 para sumar solo una vida
    public float tiempoRecoleccion = 7f;
    private float tiempoActual = 0f;
    Animator animator;
    private AudioSource audioSource;
    public AudioClip clip;


    void Start()
    {
        animator = GetComponent<Animator>();
        vidaScript = FindObjectOfType<Vida>();
        animator.SetBool("jugadorEnArea", false);
        audioSource = GetComponent<AudioSource>();

        if (vidaScript == null)
        {
            Debug.LogError("No se encontr� el script Vida en la escena.");
        }

        coralRenderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        if (jugadorEnArea)
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= tiempoRecoleccion)
            {
                Vida vidaScript = FindObjectOfType<Vida>();
                if (vidaScript != null)
                {
                    vidaScript.AgregarUnaVida(cantidadVida); // Suma solo una vida
                }

                tiempoActual = 0f;
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !coralDesactivado)
        {
            animator.SetBool("jugadorEnArea", true);

            jugadorEnArea = true;
            Debug.Log("El jugador entró en el área del coral.");
            StartCoroutine(DesactivarCoralPor5Segundos());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("jugadorEnArea", false);

            jugadorEnArea = false;
            Debug.Log("El jugador salió del área del coral.");
            // No necesitamos iniciar la corutina al salir del área del jugador
        }
    }

    IEnumerator DesactivarCoralPor5Segundos()
    {
        //coralDesactivado = true; // Marca el coral como desactivado
        yield return new WaitForSeconds(4f);
        foreach (Renderer renderer in coralRenderers)
        {
            coralDesactivado = true;
            renderer.enabled = false;
            PlaySound(clip);
        }

        /*Debug.Log("El coral se ha desactivado.");
        bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;
        audioSource.enabled = fxEnabled;
        audioSource.Play();
        */
        // No activamos el coral nuevamente, lo dejamos desactivado permanentemente
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
