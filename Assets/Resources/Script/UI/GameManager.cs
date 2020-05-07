using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int killCount = 0;
    public GameObject gameObjectToActive;
    private readonly int maxKillCount = 9;

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
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
