using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemigoPerseguir : MonoBehaviour
{
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

    
    private void Update()
    {/*

            if (target != null)
            {
                Vector3 direction = target.position - transform.position;
                direction.z = 0;
            // Debug the value returned by getPuedeComer()[0]
            Debug.Log("Is player grown up: " + playerController.getPuedeComer()[0]);

            if (playerController != null && playerController.getPuedeComer()[0]) // Check if enemy can eat grown up players
                {
                Debug.Log("Crecido EL PEZ AHORA HUEN DE MI");
                    // Run away from the player if the player is grown up
                    transform.Translate(-direction.normalized * RunSpeed * Time.deltaTime, Space.World);
                direction.z = 0;
            }
                else
            {
                Debug.Log("te queiro comer jhihi");
                // Move towards the player
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                direction.z = 0;
            }

                if (direction.magnitude <= stoppingDistance)
                {
                    // Optionally, you can add attack logic here
                }
            }
        }
        */
        Vector3 direction = target.position - transform.position;
        direction.z = 0;

        // Calculate the distance to the player
        float distanceToPlayer = direction.magnitude;

        // Check if the player is grown up
        if (playerController != null && playerController.getPuedeComer()[0])
        {
            //Debug.Log("Player is grown up!");

            // Check if the enemy should run away
            if (distanceToPlayer < runAwayRange)
            {
                //Debug.Log("Running away from the player!");
                transform.Translate(-direction.normalized * RunSpeed * Time.deltaTime, Space.World);
                direction.z = 0;
            }
            else if (distanceToPlayer < chaseRange) // Check if the enemy should chase the player
            {
               // Debug.Log("Chasing the player!");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                direction.z = 0;
            }
        }
        else // If the player is not grown up, always chase
        {
            if (distanceToPlayer < chaseRange)
            {
               // Debug.Log("Chasing the player!");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                direction.z = 0;
            }
        }


    }
}


