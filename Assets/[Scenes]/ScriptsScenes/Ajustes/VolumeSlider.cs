using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        volumeSlider.value = savedVolume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float sliderValue)
    {
        float linearVolume = Mathf.Clamp01(sliderValue); 
        if (GameAudioManager.instance != null)
        {
            GameAudioManager.instance.SetVolume(linearVolume);
        }
    }

}