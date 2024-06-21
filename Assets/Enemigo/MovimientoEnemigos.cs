using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
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
            transform.Translate(velocidad * Time.deltaTime);// zaradi tova se razpryscvat �
        }
}
