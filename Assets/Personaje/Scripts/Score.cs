using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
        // Start is called before the first frame update
        private float enemigosComidos = 0;
        public TextMeshProUGUI scoreText;
        private PlayerController playerController; // Reference to PlayerController script

        void Start()
        {
            ScoreManager.OnScoreChanged += UpdateScoreText;
            float savedScore = ScoreManager.GetScore();
            if (savedScore == 0)
            {
                UpdateScoreText(enemigosComidos);
            }
            else
            {
                UpdateScoreText(savedScore);
                enemigosComidos = savedScore;
            }
            // Find and store reference to PlayerController script
            playerController = FindObjectOfType<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                if (playerController.PuedeComerGrandes)
                {
                    if (other.gameObject.tag == "EnemyMediano")
                    {
                        enemigosComidos += 0.5f;

                    }
                    else
                    {
                        enemigosComidos += 0.25f;

                    }
                }
                else if (playerController.PuedeComerMedianos)
                {
                    enemigosComidos += 0.5f;

                }
                else
                {
                    enemigosComidos += 1;
                }

                ScoreManager.SetScore(enemigosComidos);
            }
            else if (other.CompareTag("Predator"))
            {
                // Debug.Log("CONTACTO CON PREDATPR");
                if (playerController.PuedeComerMedianos)
                {
                    enemigosComidos++;
                }

            }
            else if (other.CompareTag("PredatorGrande"))
            {
                // Debug.Log("CONTACTO CON PREDATPR");
                if (playerController.PuedeComerGrandes)
                {
                    enemigosComidos++;
                }

            }
        }

        void UpdateScoreText(float score)
        {
            if (score < 0)
            {
                score = 0;
            }

            float updatedScore = score * 100;

            scoreText.text = updatedScore.ToString();

        }

    }


