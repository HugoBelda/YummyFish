using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControllerGrande : MonoBehaviour
{
    public List<SpawnerEnemigoGrande> spawners;
    public int cantidadDeEnemigos = 5;
    public float intervaloDeAparicion = 1f; 


    public void AparecerEnemigos()
    {
        int enemigosInstanciados = 0;

        while (enemigosInstanciados < cantidadDeEnemigos)
        {
            SpawnerEnemigoGrande randomSpawner = spawners[Random.Range(0, spawners.Count)];
            randomSpawner.Spawn();
            enemigosInstanciados++;
            Debug.Log("Empeizana  aparecer ENEMIGOS GRANDES");
              
        }
    }
}
