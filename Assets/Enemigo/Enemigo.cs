using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Vector3 velocidad;
    private Vector3 targetPosition;
    public float speed = 2f;
    public float runAwayDistance = 3f; // Distance at which the enemy starts running away
    public string playerTag = "Player"; // Tag of the player GameObjec
    private Transform player;
    private float minDistance = 3f;
    private Vector3 direction;
    private bool isRunningAway = false;
    public float runAwaySpeed = 5f;

    private bool canRotate = true;
    public float rotationCooldown = 0f;

    public int pointValue = 10; // Set the default point value for the enemy

    public int pointValueWhenBig = 5;

    /* public int GetPointValue()
     {
         return pointValue;
     }
    */
    bool IsPlayerLarge(Transform playerTransform)
    {
        return playerTransform.localScale.x > 2.0f;
    }

    public int GetPointValue(Transform playerTransform)
    {
        bool isPlayerLarge = IsPlayerLarge(playerTransform);
        if (isPlayerLarge)
        {

            return pointValueWhenBig;
        }
        else
        {
            return pointValue;
        }


    }

    IEnumerator Start()
    {
        targetPosition = transform.position;
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        while (true)
        {
            velocidad = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            yield return new WaitForSeconds(2);
        }
    }
    

    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime); // zaradi tova se razpryscvat 


        direction = player.position - transform.position;

        // If the distance to the player is less than runAwayDistance, start running away
        if (direction.magnitude < runAwayDistance)
        {
            isRunningAway = true;
        }
        else
        {
            isRunningAway = false;
        }

        // Move away from the player if necessary
        if (isRunningAway)
        {
            // Calculate the opposite direction to run away from the player
            Vector3 runAwayDirection = -direction.normalized;
            // Move in that direction with runAwaySpeed
            transform.Translate(runAwayDirection * runAwaySpeed * Time.deltaTime);
        }
        else
        {
            // Otherwise, move randomly with the regular speed
            transform.Translate(velocidad * speed * Time.deltaTime);
        }
        if (canRotate)
        {
            if (velocidad.y > 0) // Moving right
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (velocidad.y < 0) // Moving left
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}