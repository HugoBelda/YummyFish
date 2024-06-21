using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public static int maxHearts = 3;
    private int currentHearts;
    public Image[] hearts;
    public Sprite fullHeartTexture;
    public Sprite emptyHeartTexture;
    private bool gameOver = false;
    private bool puedeRestarVidas = true; 
    public float tiempoSinRestarVidas = 5f; 
    private float tiempoActualSinRestarVidas = 0f;
    private CoralNormal coralScript; 
    private CoralMorado coralScript1; 
    private CoralRojo coralScript2; 


    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Nivel0")
        {
            ResetearVidas(); // Restablecer vidas al máximo al iniciar el juego
        }
        else
        {
            LoadLives(); // Cargar las vidas al iniciar otros niveles
        }
        coralScript = FindObjectOfType<CoralNormal>(); 
        coralScript1 = FindObjectOfType<CoralMorado>(); 
        coralScript2 = FindObjectOfType<CoralRojo>(); 

    }

    void Update()
    {
        if (!puedeRestarVidas)
        {
            tiempoActualSinRestarVidas += Time.deltaTime;
            if (tiempoActualSinRestarVidas >= tiempoSinRestarVidas)
            {
                puedeRestarVidas = true;
                tiempoActualSinRestarVidas = 0f;
            }
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
                hearts[i].sprite = fullHeartTexture;
            else
                hearts[i].sprite = emptyHeartTexture;
        }
    }

    public void TakeDamage(int damage)
    {
        if (puedeRestarVidas && (coralScript == null || !coralScript.jugadorEnArea)  && (coralScript1 == null || !coralScript1.jugadorEnArea)  && (coralScript2 == null || !coralScript2.jugadorEnArea)) 
        {
            for (int i = 0; i < damage; i++)
            {
                if (currentHearts > 0)
                {
                    currentHearts--;
                    hearts[currentHearts].sprite = emptyHeartTexture;
                }
            }

            if (currentHearts <= 0)
            {
                Debug.Log("Game Over!");
                gameOver = true;
                ScoreManager.ResetScore();
                SceneManager.LoadScene("gameOverScene");
            }
        }
    }

    public void AgregarVida(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (currentHearts < maxHearts)
            {
                currentHearts++;
                hearts[currentHearts - 1].sprite = fullHeartTexture;
            }
        }
    }
    public void AgregarUnaVida(int cantidad)
    {
        // Suma solo 1 vida en lugar de la cantidad especificada
        if (currentHearts < maxHearts)
        {
            currentHearts++;
            hearts[currentHearts - 1].sprite = fullHeartTexture;
        }
    }

    public void SaveLives()
    {
        PlayerPrefs.SetInt("CurrentLives", currentHearts); // Guardar las vidas actuales
    }

    public void LoadLives()
    {
        currentHearts = PlayerPrefs.GetInt("CurrentLives", maxHearts); // Cargar las vidas guardadas o el máximo
        UpdateHeartsUI(); // Actualizar la UI
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeartTexture;
            }
            else
            {
                hearts[i].sprite = emptyHeartTexture;
            }
        }
    }

    public void ResetearVidas()
    {
        currentHearts = maxHearts; 
        SaveLives(); // Guardar las vidas al restablecerlas al máximo
        UpdateHeartsUI(); 
    }
}
