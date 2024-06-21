using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezGlobo : MonoBehaviour
{

    public float tiempoCambio;
    public GameObject noInflado;
    public GameObject inflado;
    private Vida scriptVida;
    private bool infladoActivo = true; // Inicia inflado
    private bool isActive = true;



    private void Start()
    {
        scriptVida = FindObjectOfType<Vida>();
        StartCoroutine(CambiarEstado());
    }

    public IEnumerator CambiarEstado()
    {
        while (isActive)
        {
            infladoActivo = !infladoActivo; // Cambia el estado del pez
            ActualizarEstadoVisual(); // Actualiza la visualización según el estado
            yield return new WaitForSeconds(tiempoCambio);
        }
    }

    private void ActualizarEstadoVisual()
    {
        if (noInflado != null && inflado != null)
        {
            noInflado.SetActive(!infladoActivo); // Desactiva el pez inflado si está inflado
            inflado.SetActive(infladoActivo); // Activa el pez inflado si está inflado
            if (inflado.activeSelf)
            {
                bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;
                inflado.GetComponent<AudioSource>().enabled = fxEnabled;
            }
        }
        else
        {
            // Uno o ambos GameObjects han sido destruidos, ya no intentes acceder a ellos
            Debug.Log("Alguno de los GameObjects 'inflado' o 'noInflado' ha sido destruido.");
        }
    }

    // Método para manejar la acción de comer
    public void Comer()
    {
        if (!infladoActivo)
        {
            // Si el pez desinflado está activo, desactivar ambos
            // Destroy(gameObject);
            noInflado.SetActive(false);
            inflado.SetActive(false);
        }


        // Desactivar el GameObject del pez
        isActive = false;
        gameObject.SetActive(false);

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}