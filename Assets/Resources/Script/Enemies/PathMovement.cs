using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{

   
    private void Start()
    {                   
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path2"), "time", 12, "easytype", iTween.EaseType.linear));
    }
    private void Update()
    {      
        Destroy(gameObject, 5f);
    }
    
}
