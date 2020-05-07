using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text highScore;
    int currentScore = 0;
    int HScore = 0;

    private void Awake()
    {
        HScore = PlayerPrefs.GetInt("HighScore");
        highScore.text = "High Score: " + HScore;
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
    }


    public void FixedUpdate()
    {
        scoreText.text = currentScore.ToString();
        gameOverText.text = "Score: " + currentScore;
       
        if(currentScore > HScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore.text = "High Score: " + currentScore;
        }
    }
}
