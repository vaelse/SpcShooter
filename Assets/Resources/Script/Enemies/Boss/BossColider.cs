using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossColider : MonoBehaviour
{
    public float BossHP;
    public GameObject YouWon;

    private void Damage()
    {
        
        BossHP -= 0.5f;    
        if (BossHP == 0)
        {
            Destroy(gameObject);
            YouWon.SetActive(true);
        }
    }

  
       private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BlueBullet" || collision.gameObject.tag == "RedBullet")
        {            
            Destroy(collision.gameObject);
            Damage();
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        { 
            Damage();
        }
    }



}
