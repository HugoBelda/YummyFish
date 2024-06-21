using UnityEngine;
using UnityEngine.UI;

public class FXToggle : MonoBehaviour
{
    public Toggle fxToggle;

    private void Start()
    {
        bool fxEnabled = PlayerPrefs.GetInt("FXEnabled", 1) == 1;
        fxToggle.isOn = fxEnabled;
        fxToggle.onValueChanged.AddListener(SetFXEnabled);
    }

    private void SetFXEnabled(bool isEnabled)
    {
        if (FXAudioManager.instance != null)
        {
            FXAudioManager.instance.SetFXEnabled(isEnabled);
        }
    }
}