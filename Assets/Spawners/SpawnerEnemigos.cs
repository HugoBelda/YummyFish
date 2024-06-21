using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public Enemigo enemigoPrefab;

    public void Spawn()
    {
        if (enemigoPrefab != null) // Verificar si el prefab del enemigo no es nulo
        {
            Enemigo enemigoInstanciado = Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("El prefacb del enemigo es nulo. No se puede instanciar el enemigo.");
        }
    }
}