using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private static float enemigosComidosPuntuacion = 0;

    public static event System.Action<float> OnScoreChanged;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static float GetScore()
    {
        return enemigosComidosPuntuacion;
    }

    public static void SetScore(float score)
    {
        enemigosComidosPuntuacion = score;
        OnScoreChanged?.Invoke(enemigosComidosPuntuacion);
    }

    public static void ResetScore()
    {
        enemigosComidosPuntuacion = 0;
    }

    public static void ResetScoreAndNotify()
    {
        ResetScore();
        OnScoreChanged?.Invoke(enemigosComidosPuntuacion);
    }
}