using UnityEngine;
using UnityEngine.SceneManagement;

public class FXAudioManager : MonoBehaviour
{
    public static FXAudioManager instance;

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
        bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;
        SetFXEnabled(fxEnabled);
    }

    public void SetFXEnabled(bool enabled)
    {
        PlayerPrefs.SetInt("FXEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();

        UpdateFXEnabled(enabled);
    }

    private void UpdateFXEnabled(bool enabled)
    {
        UpdateAudioSourcesWithTag("Player", enabled);
        UpdateAudioSourcesWithTag("Button", enabled);
        UpdateAudioSourcesWithTag("coralMarron", enabled);
        UpdateAudioSourcesWithTag("coralRojo", enabled);
        UpdateAudioSourcesWithTag("coralMorado", enabled);
        UpdateAudioSourcesWithTag("burbujas", enabled);
        // No es necesario actualizar PredatorGrande directamente
    }

    private void UpdateAudioSourcesWithTag(string tag, bool enabled)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            AudioSource audioSource = taggedObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.enabled = enabled;
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
        bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;
        UpdateFXEnabled(fxEnabled);
    }
}