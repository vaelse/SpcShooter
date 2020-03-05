using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2Movement : MonoBehaviour
{

   
    private void Start()
    {    
           iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path1"), "time", 12, "easytype", iTween.EaseType.linear));
        
    }
    private void Update()
    {
        Destroy(gameObject, 5f);
    }
    
}
