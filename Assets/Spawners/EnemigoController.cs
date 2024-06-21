using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public List<SpawnerEnemigos> spawners;
    public int cantidadDePeces = 10;
    public float intervaloDeAparicion = 1f; // Intervalo de tiempo entre apariciones en segundos

    void Start()
    {
        spawners = new List<SpawnerEnemigos>(FindObjectsOfType<SpawnerEnemigos>());

        // Llamar a la corutina para que comience a instanciar los peces
        StartCoroutine(AparecerPeces());
    }

    IEnumerator AparecerPeces()
    {
        int pecesInstanciados = 0;

        // Instanciar la cantidad deseada de peces
        while (pecesInstanciados < cantidadDePeces)
        {
            SpawnerEnemigos randomSpawner = spawners[Random.Range(0, spawners.Count)];
            randomSpawner.Spawn();
            pecesInstanciados++;

            // Esperar el intervalo de tiempo antes de instanciar el siguiente pez
            yield return new WaitForSeconds(intervaloDeAparicion);
        }
    }
}