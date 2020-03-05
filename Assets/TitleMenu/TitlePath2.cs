using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePath2 : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Game"), "time", 2, "easytype", iTween.EaseType.linear));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
