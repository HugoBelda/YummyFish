using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPausa : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        AudioManager.Instance.PlaySound();
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        AudioManager.Instance.PlaySound();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void salir()
    {
        AudioManager.Instance.PlaySound();
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void volverAlInicio()
    {
        AudioManager.Instance.PlaySound();
        Time.timeScale = 1;
        ScoreManager.ResetScore();
        StartCoroutine(LoadSceneWithDelay("MainScene2", 0.3f)); // Cambia el tiempo de retraso según necesites
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}