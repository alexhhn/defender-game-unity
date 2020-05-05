using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public int score;
    public float enemySpeedIncreaseOvertime = 1f;

    public TextMeshProUGUI scoreText;
    private float currentTime = 0; 
    private float timeIncreaseRate = 5f;

    // public float restartDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score + " Mæber";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Time.time > currentTime)
        {
            enemySpeedIncreaseOvertime += 0.1f;
            currentTime = Time.time + timeIncreaseRate;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score + ": Mæber";
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOver");
        }
    }
}
