using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedEnemies : MonoBehaviour
{
    [SerializeField]
    private float EnemyHP = 4;
    private readonly int RedScore = 80;
    public Animator animator;

    private Material WhiteMat;
    private Material DefaultMat;
    SpriteRenderer sr;
    GameManager killcount;
    ScoreController score;   
    EnemiesController EnemyCount;

    private void Start()
    {
        //White flash components
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Assets/Materials/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        killcount = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject Red = GameObject.FindGameObjectWithTag("enemyspawn");
        EnemyCount = Red.GetComponent<EnemiesController>();
    }

    private void Update()
    {
        animator.SetFloat("Health", EnemyHP);
    }

    public void Destroyed()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        EnemyCount.maxEnemies--;
        Destroy(gameObject,0.60f);      
        score.IncreaseScore(RedScore);
        killcount.KillIncrease();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "BossLazer")
        {
            Damaged(.5f, null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBullet")
        {
            Damaged(1, collision);
        }      
    }

    public void Damaged(float damage, Collider2D collider )
    {
        sr.material = WhiteMat;
        EnemyHP--;
        if (collider != null)
        {
            Destroy(collider.gameObject);
        }
        if (EnemyHP == 0)
        {
            sr.material = DefaultMat;
            Destroyed();
        }
        else
        {
            Invoke("ResetMaterial", 0.06f);
        }
    }

    void ResetMaterial()
    {
        sr.material = DefaultMat;
    }
}
