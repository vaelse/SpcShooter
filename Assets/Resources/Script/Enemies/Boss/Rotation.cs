using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("Rota", 2f, 25f);
        
    }
   
   public void Rota()
    {
                iTween.RotateTo(gameObject, iTween.Hash("z", 0, "time", 2f,"easetype", "easeOutQuad", "oncomplete", "Rotadown"));

    }
    public void Rotaback()
    {
        iTween.RotateTo(gameObject, iTween.Hash("z", 90, "time", 1f, "easetype", "easeOutQuad"));

    }
    public void Rotadown()
    {

        iTween.RotateTo(gameObject, iTween.Hash("z", 180, "time", 2f, "easetype", "easeOutQuad", "oncomplete", "Rotaback"));

    }
}
