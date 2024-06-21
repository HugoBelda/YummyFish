using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class abrirAjustes : MonoBehaviour
{
    public AudioClip soundToPlay;

    public void OnClickHandler()
    {
        StartCoroutine(PlaySoundAndLoadScene(soundToPlay));
    }

    IEnumerator PlaySoundAndLoadScene(AudioClip clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("ajustesScript requires an AudioSource component!");
            yield break;
        }

        audioSource.clip = clip;
        audioSource.Play();

        // Espera hasta que el sonido termine de reproducirse
        yield return new WaitForSeconds(clip.length);

        // Carga la escena después de que el sonido haya terminado
        SceneManager.LoadScene("MenuAjustes");
    }
}