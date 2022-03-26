using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float Score = 0;
    public float Multiplier = 1;
    public TMPro.TextMeshProUGUI UIScore;
    public TMPro.TextMeshProUGUI UIMultiplier;
    public TMPro.TextMeshProUGUI UITimer;
    float timer = 30f;

    private void Start()
    {
        Time.timeScale = 1f;
        updateUI();
    }

    private void Update()
    {
        // Timer
        if (timer > 0)
        {
            // Timer: - countdown & display
            timer -= Time.deltaTime;
            UITimer.text = "Timer: " + Mathf.Round(timer).ToString();
        } else
        {
            // Game Over
            GameOver();
        }
    }


    public void updateUI()
    {
        UIScore.text = "Score: " + Score;
        UIMultiplier.text = "Multiplier: " + Multiplier;
    }
    public void ScoreUpdater()
    {
        Score++;
        IncreaseMultipler();
        updateUI();
    }

    public void IncreaseMultipler()
    {
        Multiplier += 0.1f;
        updateUI();
    }

    public void DecreaseMultiplier()
    {
        Multiplier -= 0.3f;
        if (Multiplier < 1f)
        {
            Multiplier = 1f;
        }
        updateUI();
    }

    public void DecreaseScore()
    {
        if (Score > 1)
        {
            Score--;
        }
        updateUI();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
