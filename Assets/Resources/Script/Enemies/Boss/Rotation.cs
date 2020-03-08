using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("RotationUp", 2f, 25f);
    }

    public void RotationUp()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 0, "time", 2f, "easetype", "easeOutQuad", "oncomplete", "Rotationdown"));

    }
    public void Rotationback()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 90, "time", 1f, "easetype", "easeOutQuad"));

    }
    public void Rotationdown()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 180, "time", 2f, "easetype", "easeOutQuad", "oncomplete", "Rotationback"));
    }

 }
