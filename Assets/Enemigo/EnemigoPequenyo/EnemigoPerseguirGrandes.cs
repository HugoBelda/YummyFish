using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguirGrandes : MonoBehaviour
{
    [SerializeField] float velocidad = 4.0f;
    private PlayerController playerController;
    private bool isChasing = false;
    public float moveSpeed = 5f;
    public float RunSpeed = 7f;
    public float stoppingDistance = 1f;

    public float chaseRange = 5f; // Range within which the enemy will chase the player
    public float runAwayRange = 3f; // Range within which the enemy will run away from the player

    private Transform target;
    //private Controller controller;

    private void Start()
    {
        // Find the target object with the specified layer
        GameObject targetObject = GameObject.FindWithTag("Player"); // Assuming your target object has the "Player" tag
        if (targetObject != null)
        {
            target = targetObject.transform;
            playerController = targetObject.GetComponent<PlayerController>(); // Assuming PlayerController is on the target object
        }
        else
        {
            Debug.LogWarning("Target object not found!");
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (target == null || playerController == null)
            return;

        Vector3 direction = target.position - transform.position;
        direction.z = 0;

        float distanceToPlayer = direction.magnitude;

        // Check if the player is grown up for the second time
        if (playerController.getPuedeComer()[1])
        {
            // Player has grown up for the second time
            if (distanceToPlayer < runAwayRange)
            {
                // Enemy should run away
                transform.Translate(-direction.normalized * RunSpeed * Time.deltaTime, Space.World);

            }
            else if (distanceToPlayer < chaseRange)
            {
                // Enemy should chase the player
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            // Player has not grown up for the second time, always chase
            if (distanceToPlayer < chaseRange)
            {
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            }
        }

        if (distanceToPlayer <= stoppingDistance)
        {
            // Optionally, you can add attack logic here
        }
    }
}

    /*
    // Check if the player is grown up
    Vector3 direction = target.position - transform.position;
    direction.z = 0;

    // Calculate the distance to the player
    float distanceToPlayer = direction.magnitude;

    // Check if the player is grown up for the second time
    if (playerController != null && playerController.getPuedeComer()[0])
    {
        Debug.Log("Player is grown up for the first time!");
        if (playerController != null && playerController.getPuedeComer()[1])
        {
            Debug.Log("Player is grown up for the 2 time!");
            // Check if the enemy should run away
            if (distanceToPlayer < runAwayRange)
            {
                Debug.Log("Running away from the player!");
                transform.Translate(-direction.normalized * RunSpeed * Time.deltaTime, Space.World);
                direction.z = 0;

            }
            else if (distanceToPlayer < chaseRange) // Check if the enemy should chase the player
            {
                Debug.Log("Chasing the player!");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                direction.z = 0;

            }
        }
        else // If the player is not grown up for the second time, always chase
        {
            if (distanceToPlayer < chaseRange)
            {
                Debug.Log("Chasing the player!");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            }
        }

        if (distanceToPlayer <= stoppingDistance)
        {
            // Optionally, you can add attack logic here
        }


    }
    */

    /*
    //Necesitamos la distancia a la que el enemigo viene a atacarnos
    //Campo serializado para que no pueda cambiarse fuera de la clase pero que aparezca en el inspector
    [SerializeField] float velocidad = 4.0f;
    private PlayerController playerController;
    //Necesitamos la posici�n del jugador
    Transform jugador;
    public float chaseRange = 4f; // Range within which the enemy starts chasing the player

    private Transform player; // Reference to the player's transform
    private Vector3 originalPosition; // Store the original position between pointA and poin
    private Vector3 targetPosition;
    public float speed = 2f;
    private Vector3 direction;
    public float runAwayDistance = 15f;
    public float runAwaySpeed = 5f;
    //Vector3 velocidad;



    void Start()
    {
        //Asignar un valor a jugador, lo encontraremos porque es el �nico que va a tener el script Character. con transform obtenemos la posici�n
        jugador = FindObjectOfType<Character>().transform;
        //= GameObject.FindGameObjectWithTag("Player");
        playerController = jugador.GetComponent<PlayerController>();

    }

    // Update is called once per frame


    void Update()
    {
        //Mover el enemigo  
        //Direcci�n (recta de vectores: D = B-A)
        Vector3 movimiento = jugador.position - transform.position;
        //.normalized -> con la misma direcci�n, un vector de magnitud 1
        //El tiempo debe ser independiente -> Time.deltaTime
        transform.Translate(movimiento.normalized * velocidad * Time.deltaTime);
    }
    */


