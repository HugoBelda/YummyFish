using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Playables;
using System.Runtime.CompilerServices;

public class PlayerController1 : MonoBehaviour
{
    private bool yaHaEscalado = false;
    private bool yaHaEscalado2 = false;
    private bool sizeIncreased2 = false;
    private float initialScale;
    private bool puedeComerGrandes = false;
    private bool puedeComerMedianos = false;
    private bool isInvulnerable = false;

    public float tiempoRecargaPredator = 2f;
    private bool recargaPredator = false;
    public GameObject efectoBurbujas;

    //Cosasanyadiada---------
    public AnimationCTR animationctr;
    //--------------------



    //public TextMeshProUGUI scoreText;

    public EnemigoControllerGrande enemigoControllerGrande;

    public BarraProgress1 barraProgress;

    public float increaseSizeFactor = 1.5f;


    public bool PuedeComerMedianos
    {
        get { return puedeComerMedianos; }
    }
    public bool PuedeComerGrandes
    {
        get { return puedeComerGrandes; }
    }

    void Start()
    {
        initialScale = transform.localScale.x;
        barraProgress = FindObjectOfType<BarraProgress1>();
        enemigoControllerGrande = FindObjectOfType<EnemigoControllerGrande>();
    }
   IEnumerator iniciarRecargaPredator()
    {
        yield return new WaitForSeconds(tiempoRecargaPredator);
        recargaPredator = false;
    }


    private void Update()
    {
        if (barraProgress.progressBar.value >= (1f / 3f) * barraProgress.progressBar.maxValue && !yaHaEscalado)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f,
                transform.localScale.z * 1.5f);
            GameObject burbujas = Instantiate(efectoBurbujas, transform.position, Quaternion.identity);
            burbujas.transform.SetParent(transform);
            burbujas.transform.localScale = Vector3.one;
            Destroy(burbujas, 4f);
       
            yaHaEscalado = true;

            puedeComerMedianos = true;
            enemigoControllerGrande.AparecerEnemigos();
            Debug.Log("Aparecen enemigos" );
        }

        else if (barraProgress.progressBar.value >= (2f / 3f) * barraProgress.progressBar.maxValue && !yaHaEscalado2)
        {

            Debug.Log("escalado 2/3 - progreso: " + barraProgress.progressBar.value);
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f,
                transform.localScale.z * 1.5f);
            GameObject burbujas = Instantiate(efectoBurbujas, transform.position, Quaternion.identity);
            burbujas.transform.SetParent(transform);
            burbujas.transform.localScale = Vector3.one;
            Destroy(burbujas, 4f);
            puedeComerGrandes = true;
            yaHaEscalado2 = true;
        }

        

    }



    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Call method to update progress when enemy is destroyed
            //barraProgress.EnemyDestroyed(enemy);
        }
        else if (other.CompareTag("Predator"))
        {
            HandlePredatorCollision(other);
            Debug.Log("Ahora PUEDES COMER PREDATOR");
        }
        else if (other.CompareTag("PredatorGrande"))
        {
            HandleLargePredatorCollision(other);

        }
       /* else if (other.CompareTag("PezGlobo"))
        {
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("PezGloboInchado"))
        {
           HandlePezGloboCollision

        }
       */
    }

    void HandlePredatorCollision(Collider other)
    {
        if (puedeComerMedianos || isInvulnerable)
        {
            Destroy(other.gameObject);
            //Cosas anyaddidas------
            animationctr.StartCoroutine("PlayComer");
            //-----------------------------
        }
        else
        {
            Vida vidaScript = GetComponent<Vida>();
            if (vidaScript != null)
            {
                vidaScript.TakeDamage(1);
                //-----------------------------
                animationctr.StartCoroutine("PlayHit");
                //-----------------------------
            }
        }

    }

    void HandleLargePredatorCollision(Collider other)
    {


        if (puedeComerGrandes || isInvulnerable)
        {
            Destroy(other.gameObject);
            //-----------------------------
            animationctr.StartCoroutine("PlayComer");
            //-----------------------------
        }
        else
        {

            //Vida vidaScript = GetComponent<Vida>();
            Vida vidaScript = GetComponent<Vida>();

            if (vidaScript != null && !recargaPredator)
            {
                vidaScript.TakeDamage(1);
              recargaPredator = true;
                //-----------------------------
                animationctr.StartCoroutine("PlayHit");
                //-----------------------------
                StartCoroutine(iniciarRecargaPredator());
            }

        }

    }

  /*  void HandlePezGloboCollision(Collider other)
    {

            //Vida vidaScript = GetComponent<Vida>();
            Vida vidaScript = GetComponent<Vida>();

            if (vidaScript != null)
            {
                vidaScript.TakeDamage(1);
            }

    }
  */


    public bool[] getPuedeComer()
    {
        bool[] LosQuePuede = { puedeComerMedianos, puedeComerGrandes };
        return LosQuePuede;
    }

    public bool IsGrownUp()
    {
        // Check if the player's scale is larger than the initial scale
        return transform.localScale.x > initialScale;
    }


}