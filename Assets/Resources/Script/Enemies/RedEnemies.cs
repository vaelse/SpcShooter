using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedEnemies : MonoBehaviour
{
    [SerializeField]
    private float enemyHP = 4;
    private readonly int redScore = 80;
    public Animator animator;

    private Material whiteMat;
    private Material defaultMat;
    SpriteRenderer sr;
    GameManager killCount;
    ScoreController killScore;   
    EnemiesController redEnemySpawner;

    private audiomanager audioManager;

    private void Start()
    {
        //White flash components
        sr = gameObject.GetComponent<SpriteRenderer>();
        whiteMat = Resources.Load("Assets/Materials/WhiteFlash", typeof(Material)) as Material;
        defaultMat = sr.material;

        killScore = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        killCount = GameObject.Find("GameManager").GetComponent<GameManager>();

        redEnemySpawner = GameObject.FindGameObjectWithTag("enemyspawn").GetComponent<EnemiesController>();
       
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<audiomanager>();
    }

    private void Update()
    {
        animator.SetFloat("Health", enemyHP);
    }

    public void Destroyed()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        redEnemySpawner.maxEnemies--;
        Destroy(gameObject,0.60f);      
        killScore.IncreaseScore(redScore);
        killCount.KillIncrease();
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
        sr.material = whiteMat;
        enemyHP--;
        if (collider != null)
        {
            Destroy(collider.gameObject);
        }
        if (enemyHP == 0)
        {
            audioManager.Explosound();
            sr.material = defaultMat;
            Destroyed();
        }
        else
        {
            Invoke("ResetMaterial", 0.06f);
        }
    }

    void ResetMaterial()
    {
        sr.material = defaultMat;
    }
}
