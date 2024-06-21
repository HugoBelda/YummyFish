using UnityEngine;

public class Alga : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip entradaPersonaje;
    public AudioClip ganarVida;
    public float tiempoRecoleccion = 5f;
    public int cantidadVida = 1;

    private bool jugadorEnArea = false;
    private float tiempoActual = 0f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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
                    vidaScript.AgregarVida(cantidadVida);
                    PlaySound(ganarVida);

                }

                tiempoActual = 0f;
            }
        }
    }
    void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
           audioSource.PlayOneShot(clip);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnArea = true;
            PlaySound(entradaPersonaje);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnArea = false;
            tiempoActual = 0f;
            PlaySound(entradaPersonaje);

        }
    }
}
