using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMana : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
        Invoke("ButtonActivation", 3f);
    }

   public void ButtonActivation()
    {
        button.SetActive(true);
    }
}
