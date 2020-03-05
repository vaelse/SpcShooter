using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueEnemies : MonoBehaviour
{
    public float EnemyHP;
    private Material WhiteMat;
    private Material DefaultMat;
    SpriteRenderer sr;
    ScoreController score;
    GameManager killcount;
    public int BlueScore = 100;
    EnemiesController EnemiesCount;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Material/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        killcount = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject Blue = GameObject.FindGameObjectWithTag("enemyspawn");
        EnemiesCount = Blue.GetComponent<EnemiesController>();
}
    public void Destroyed()
    {
        EnemiesCount.MaxEnemies--;
        Destroy(gameObject);
        score.IncreaseScore(BlueScore);
        killcount.KillIncrease();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BlueBullet")
        {
            EnemyHP--;
            Destroy(collision.gameObject);
            sr.material = WhiteMat;
            if (EnemyHP == 0)
            {
                Destroyed();           
            }
            else
            {
                Invoke("ResetMaterial", 0.09f);
            }

        }
      
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "BossLazer")
        {
            EnemyHP -= 0.5f;
            sr.material = WhiteMat;
            if (EnemyHP == 0)
            {
                Destroyed();
            }
            else
            {
                Invoke("ResetMaterial", 0.09f);
            }
        }
    } 
    void ResetMaterial()
    {
        sr.material = DefaultMat;
    }
    
}
