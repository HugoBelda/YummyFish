using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGrande : MonoBehaviour
{

    public int pointValue = 30;// Set the default point value for the enemy
    private int pointValueWhenSmall = 0;
    // Method to get the point value of the enemy


    bool IsPlayerLarge(Transform playerTransform)
    {
        return playerTransform.localScale.x > 3.0f;
    }
    public int GetPointValue(Transform playerTransform)
    {
        bool isPlayerLarge = IsPlayerLarge(playerTransform);
        if (isPlayerLarge)
        {
            return pointValue;
        }
        else
        {
            return pointValueWhenSmall;
        }


    }
    Vector3 velocidad;
    private Vector3 targetPosition;
    public float speed = 2f;
    public string playerTag = "Player"; // Tag of the player GameObjec
    private Transform player;



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
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime);// zaradi tova se razpryscvat ç
    }
}