using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    private void Start()
    {
        if (GameAudioManager.instance != null)
        {
            float volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
            GameAudioManager.instance.SetVolume(volume);
        }
    }
}