using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public Image HealthBar;
    public Image LaserBar;   
    public GameObject GameoverButton;
     
    public void Update()
    {
        if (HealthBar.fillAmount > 0.25)
        {
            HealthBar.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemybullet")
        {
            Destroy(collision.gameObject);
            Damaged(0.25f);
        }
        else if(collision.gameObject.tag == "HealthBox")
        {
            HealthBar.fillAmount += 0.25f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "AmmoBox")
        {
            Destroy(collision.gameObject);
            LaserBar.fillAmount += 0.25f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BossLazer")
        {
            Damaged(0.1f);
        }
    }

    public void Damaged(float PlayerHealthDamage)
    {           
            HealthBar.fillAmount = HealthBar.fillAmount - PlayerHealthDamage;
            if (HealthBar.fillAmount <= 0.25)
            {
                HealthBar.color = Color.red;
            }
            else if (HealthBar.fillAmount == 0)
            {
                GameoverButton.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }
    }

