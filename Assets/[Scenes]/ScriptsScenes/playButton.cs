using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playButton : MonoBehaviour
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
            Debug.LogError("playButton requires an AudioSource component!");
            yield break;
        }

        audioSource.clip = clip;
        audioSource.Play();

        // Espera hasta que el sonido termine de reproducirse
        yield return new WaitForSeconds(clip.length);

        SceneManager.LoadScene("Nivel0");
    }
}