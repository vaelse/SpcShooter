using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    public Text ScoreText;
    public Text GameOverText;
    public Text HighScore;
    int CurrentScore = 0;
    int HScore = 0;

    private void Awake()
    {
        HScore = PlayerPrefs.GetInt("HighScore");
        HighScore.text = "High Score: " + HScore;
    }

    public void IncreaseScore(int points)
        {

        CurrentScore += points;

        }


    public void FixedUpdate()
    {
        ScoreText.text = CurrentScore.ToString();
        GameOverText.text = "Score: " + CurrentScore;
       
        if(CurrentScore > HScore)
        {
            PlayerPrefs.SetInt("HighScore", CurrentScore);
            HighScore.text = "High Score: " + CurrentScore;
        }
    }
}
