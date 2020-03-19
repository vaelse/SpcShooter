using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMana : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ButtonActivation", 3f);
    }

   public void ButtonActivation()
    {
        button.SetActive(true);
    }
}
