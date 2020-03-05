using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int killcount = 0;
    public GameObject gameobjecttoactive;
    private int MaxKillcount = 10;

    public void KillIncrease()
    {
        killcount++;
    }
    public void Update()
    {
        if (killcount >= MaxKillcount)
        {
            gameobjecttoactive.SetActive(true);
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
