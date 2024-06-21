using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControler2 : MonoBehaviour
{
    public List<SpawnerEnemigoMediano> spawners;
    public int cantidadDeEnemigos = 5;
    public float intervaloDeAparicion = 1f; // Intervalo de tiempo entre apariciones en segundos

    void Start()
    {
        spawners = new List<SpawnerEnemigoMediano>(FindObjectsOfType<SpawnerEnemigoMediano>());

        // Llamar a la corutina para que comience a instanciar los enemigos
        StartCoroutine(AparecerEnemigos());
    }

    IEnumerator AparecerEnemigos()
    {
        int enemigosInstanciados = 0;

        // Instanciar la cantidad deseada de enemigos
        while (enemigosInstanciados < cantidadDeEnemigos)
        {
            SpawnerEnemigoMediano randomSpawner = spawners[Random.Range(0, spawners.Count)];
            randomSpawner.Spawn();
            enemigosInstanciados++;

            // Esperar el intervalo de tiempo antes de instanciar el siguiente enemigo
            yield return new WaitForSeconds(intervaloDeAparicion);
        }
    }
}