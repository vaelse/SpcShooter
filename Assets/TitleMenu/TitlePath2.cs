using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePath2 : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Game"), "time", 2, "easytype", iTween.EaseType.linear));
    }
}
