using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public AudioClip soundToPlay;

    private AudioSource audioSource;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("AudioManager");
                obj.AddComponent<AudioSource>();
                _instance = obj.AddComponent<AudioManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        if (audioSource != null && soundToPlay != null)
        {
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager: AudioSource or soundToPlay is not assigned.");
        }
    }
}