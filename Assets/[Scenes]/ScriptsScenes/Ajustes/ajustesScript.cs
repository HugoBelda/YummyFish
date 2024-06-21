using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ajustesScript : MonoBehaviour
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

        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("MainScene2");
    }
}