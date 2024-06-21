using UnityEngine;

public class PredatorGrandeHandler : MonoBehaviour
{
    private void OnEnable()
    {
        // Obtener el valor guardado para FXEnabled
        bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;

        // Buscar y actualizar el AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.enabled = fxEnabled;
        }
    }
}