using UnityEngine;

public class StopMusicOnLoad : MonoBehaviour
{
    private void Start()
    {
        if (GameAudioManager.instance != null)
        {
            GameAudioManager.instance.StopMusic();
        }
    }
}