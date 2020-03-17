using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int killCount;
    public GameObject gameObjectToActive;
    private int maxKillCount = 10;

    public void KillIncrease()
    {
        killCount++;
    }
    public void Update()
    {
        if (killCount >= maxKillCount)
        {
            gameObjectToActive.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
