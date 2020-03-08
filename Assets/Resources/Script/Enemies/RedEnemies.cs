using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedEnemies : MonoBehaviour
{
    public float EnemyHP ;

    private Material WhiteMat;
    private Material DefaultMat;
    SpriteRenderer sr;

    GameManager killcount;
    ScoreController score;
    public int RedScore = 80;
    EnemiesController EnemyCount;

    private void Start()
    {
        //White flash components
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Material/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        killcount = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Max Enemies Count
        GameObject Red = GameObject.FindGameObjectWithTag("enemyspawn");
        EnemyCount = Red.GetComponent<EnemiesController>();
    }

    public void Destroyed()
    {
        EnemyCount.MaxEnemies--;
        Destroy(gameObject);      
        score.IncreaseScore(RedScore);
        killcount.KillIncrease();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBullet")
        {
            sr.material = WhiteMat;
            EnemyHP --;
            Destroy(collision.gameObject);
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
