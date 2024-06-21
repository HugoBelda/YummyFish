using UnityEngine;

public class Marea : MonoBehaviour
{
    private AudioSource audioSource;

    public float velocidadMarea = 5f; // Velocidad de la marea
    public float direccionX = 1f; // Direcci�n de la marea en el eje X
    public float velocidadReducida = 1f; // Velocidad reducida del jugador cuando est� en el �rea de la marea
    public AudioClip marea;

    public CharacterController controller;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    /* private void Start()
     {
         controller = GameObject.FindWithTag("Player").GetComponentInChildren<CharacterController>;
     }
    */
    private void FixedUpdate()
    {
        // Mover la marea en la direcci�n especificada
        transform.Translate(Vector3.right * direccionX * velocidadMarea * Time.deltaTime);


        /*   if (jugadorEnArea)
           {
               // Reducir la velocidad del jugador
               controller.Move(Vector3.right * direccionX * velocidadReducida * Time.deltaTime);
           }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller = other.GetComponent<CharacterController>();
            controller.Move(Vector3.right / 3);
            PlaySound(marea);
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
            StartCoroutine(StopSoundAfterDelay(1f)); // Detener el sonido después de 1 segundo
        }
    }

    private System.Collections.IEnumerator StopSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Stop();
    }
}