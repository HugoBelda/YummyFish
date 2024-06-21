 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigoMediano : MonoBehaviour
{
    public GameObject enemigoPrefab;

    public void Spawn()
    {
        if (enemigoPrefab != null) // Verificar si el prefab del enemigo no es nulo
        {
            GameObject enemigoInstanciado = Instantiate(enemigoPrefab, transform.position,transform.rotation);
        }
        else
        {
            Debug.LogWarning("El prefacb del enemigo es nulo. No se puede instanciar el enemigo.");
        }
    }
}