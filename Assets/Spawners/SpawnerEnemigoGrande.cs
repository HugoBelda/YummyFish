using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigoGrande : MonoBehaviour
{
    public GameObject enemigoPrefab;

    public void Spawn()
    {
        if (enemigoPrefab != null)
        {
            GameObject enemigoInstanciado = Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("El prefacb del enemigo es nulo. No se puede instanciar el enemigo.");
        }
    }
}