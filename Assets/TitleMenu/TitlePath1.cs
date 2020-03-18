using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePath1 : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Start"), "time", 2, "easytype", iTween.EaseType.linear));
    }
}
