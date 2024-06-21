using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;

    private float savedVolume = 1f; // Guardar el último volumen establecido antes de silenciar

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();

        if (volume > 0)
        {
            savedVolume = volume;
            UpdateVolume(volume);
        }
        else
        {
            savedVolume = 0f;
            MuteMusic(true);
        }
    }

    private void UpdateVolume(float volume)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Musica");
        foreach (GameObject taggedObject in taggedObjects)
        {
            AudioSource audioSource = taggedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
    }

    private void MuteMusic(bool mute)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Musica");
        foreach (GameObject taggedObject in taggedObjects)
        {
            AudioSource audioSource = taggedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = mute ? 0f : savedVolume;
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic();
    }

    public void StopMusic()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Musica");
        foreach (GameObject taggedObject in taggedObjects)
        {
            AudioSource audioSource = taggedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}
