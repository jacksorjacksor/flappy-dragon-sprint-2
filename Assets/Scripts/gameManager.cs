using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    

    public GameObject GameOverPanel;
    public dragonController dragonController;
    
    public TMPro.TextMeshProUGUI UIScore;
    public TMPro.TextMeshProUGUI UIMultiplier;
    public TMPro.TextMeshProUGUI UITimer;
    public TMPro.TextMeshProUGUI UIFireballChargerCounter;
    public TMPro.TextMeshProUGUI UIFireballCounter;

    float startingTimeValue = 30f;
    float timer;
    float Score = 0;
    public float Multiplier = 1;
    public int fireballChargerCounter = 0;
    public bool fireballReady = false;
    public columnSpawner columnSpawner;
    public GameObject columnParent;
    public GameObject StartGamePrompt;

    public bool gamePlayActive = false;

    private void Start()
    {
        Time.timeScale = 1f;
        timer = startingTimeValue;
        updateUI();
        StartGamePrompt.GetComponent<Animation>().Play("text-flashing");
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        // start Game
        if (!gamePlayActive && Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: add credits (can only start playing if you have credits)
            startGame();
        }

        // Timer
        if (gamePlayActive)
        {
            if (timer > 0)
            {
                // Timer: - countdown & display
                timer -= Time.deltaTime;
                UITimer.text = "Timer: " + Mathf.Round(timer).ToString();
            }
            else
            {
                GameOver();
            }
        }
    }

    public void startGame()
    {
        columnSpawner.spawnColumn();
        StartGamePrompt.SetActive(false);
        Time.timeScale = 1f;
        gamePlayActive = true;
        dragonController.ReadyToFly();
        GameOverPanel.SetActive(false);
        Multiplier = 1f;
        Score = 0;
    }



    public void updateUI()
    {
        UIScore.text = "Score: " + Score;
        UITimer.text = "Timer " + timer; 
    }
    public void ScoreUpdater()
    {
        Score++;
        IncreaseMultipler();
        updateUI();
        if (!fireballReady)
        {
            fireballChargerCounter++;
            FireballChecker();
        }
    }

    public void FireballChecker()
    {
        if (fireballChargerCounter.Equals(4))
        {
            fireballChargerCounter = 0;
            fireballReady=true;
        }
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
        gamePlayActive=false;
        Time.timeScale = 0;
        timer = startingTimeValue;
        GameOverPanel.SetActive(true);
        // Destroy all children
        foreach (Transform child in columnParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        dragonController.BackToStartingPosition();
        fireballReady = false;
        fireballChargerCounter = 0;
    }   
}
