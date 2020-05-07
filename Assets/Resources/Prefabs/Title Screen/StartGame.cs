using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //starts the game from main menu
  public void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
