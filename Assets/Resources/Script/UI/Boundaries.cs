using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera MainCam;
    private Vector2 bounds;
    
    public float ObjectWidth;
    public float ObjectHeight;

    void Start()
    {
        //gets width and height of the screen
        bounds = MainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCam.transform.position.z));
        ObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        ObjectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; 
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, bounds.x * -1 + ObjectWidth, bounds.x - ObjectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, bounds.y * -1 + ObjectHeight, bounds.y - ObjectHeight);
        transform.position = viewPos;
    }
}
