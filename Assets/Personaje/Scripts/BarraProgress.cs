using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BarraProgress : MonoBehaviour
{
    public Animator animator;
    public UnityEngine.UI.Slider progressBar;
    private float accumulatedTime = 0f;
    
    private int totalEnemies;
    private int totalPredators;
    private int totalLargePredators;

    private int enemiesDestroyed = 0;
    private int predatorsDestroyed = 0;
    private int largePredatorsDestroyed = 0;

    private float totalPointsToCollect;

    private int pointsCollected;


    public GameObject panel;
    public float timeToDisable = 5f;

    void Start()
    {
        panel.gameObject.SetActive(true); // Activate the panel initially

        CalculateTotalPointsToCollect();
        UpdateProgressBar();
    }

    private void Update()
    {
        UpdateProgressBar();
        CheckNextScene();

        accumulatedTime += Time.deltaTime;
        if (accumulatedTime >= timeToDisable)
        {
            panel.gameObject.SetActive(false);
            accumulatedTime = 0f; 
        }
    }
    private void UpdateProgressBar()
    {
        float progress = (float)pointsCollected / totalPointsToCollect;

        if (progressBar != null)
        {
            progressBar.value = progress;
            Debug.Log("Progress: " + progress);
        }
    }

    private void CalculateTotalPointsToCollect()
    {
        totalPointsToCollect = 10f;
    }

    public void EnemyDestroyed(Enemigo enemy, Transform p)
    {
        pointsCollected += enemy.GetPointValue(p);
        UpdateProgressBar();
        Debug.Log("Enemy destroyed! Points collected: " + pointsCollected);
    }


    public void Enemy2Destroyed(EnemigoMediano2 enemy, Transform p)
    {
        // pointsCollected += enemy.pointValue;
        pointsCollected += enemy.GetPointValue(p);
        UpdateProgressBar();
        Debug.Log("Enemy2 destroyed! Points collected: " + pointsCollected);
    }

    public void Enemy3Destroyed(EnemigoGrande enemy, Transform p)
    {
        // pointsCollected += enemy.pointValue;
        pointsCollected += enemy.GetPointValue(p);
        UpdateProgressBar();
        Debug.Log("Enemy2 destroyed! Points collected: " + pointsCollected);
    }

    /* private bool DestroyObject(GameObject obj)
     {
         if (obj != null)
         {
             Destroy(obj);
             return true;
         }
         return false;
     }
    */

    private void OnTriggerEnter(Collider other)
    {
        Enemigo enemy = other.GetComponent<Enemigo>();
        EnemigoMediano2 enemy2 = other.GetComponent<EnemigoMediano2>();
        EnemigoGrande enemy3 = other.GetComponent<EnemigoGrande>();

        if (enemy != null)
        {
            EnemyDestroyed(enemy, transform);
        }
        else if (enemy2 != null)
        {
            Enemy2Destroyed(enemy2, transform);
        }
        else if (enemy3 != null)
        {
            Enemy3Destroyed(enemy3, transform);
        }
    }

    void ResetScoreAndProgressBar()
    {
        pointsCollected = 0;

        progressBar.value = pointsCollected;
    }


    void CheckNextScene()
    {
        if (progressBar.value == progressBar.maxValue)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            string nextScene = "";

            if (currentScene == "Nivel0")
            {
                nextScene = "Nivel1";
                StartCoroutine(LoadScene(nextScene, .5f)); // Load scene with delay using coroutine
            }
            else if (currentScene == "Nivel1")
            {
                nextScene = "YouWin";
                ScoreManager.ResetScore();
            }

            Vida vidaScript = GetComponent<Vida>();
            if (vidaScript != null)
            {
                vidaScript.SaveLives(); // Guardar vidas antes de cambiar de escena
            }
        }
    }


    IEnumerator LoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}