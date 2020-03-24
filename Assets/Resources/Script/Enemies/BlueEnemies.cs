using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueEnemies : MonoBehaviour
{
    private float EnemyHP = 3;
    private readonly int blueScore = 100;

    public Animator animator;

    private Material WhiteMat;
    private Material DefaultMat;
    private SpriteRenderer sr;
    private ScoreController score;
    private GameManager killcount;
    private EnemiesController blueEnemySpawner;
    private audiomanager audioManager;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Assets/Materials/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        killcount = GameObject.Find("GameManager").GetComponent<GameManager>();

        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<audiomanager>();

        blueEnemySpawner = GameObject.FindGameObjectWithTag("enemyspawn").GetComponent<EnemiesController>();
      
    }
    private void Update()
    {
        animator.SetFloat("Health", EnemyHP);
    }
    private void Destroyed()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        blueEnemySpawner.maxEnemies--;
        Destroy(gameObject, 0.6f);
        score.IncreaseScore(blueScore);
        killcount.KillIncrease();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlueBullet")
        {
            Damaged( 1, collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "BossLazer")
        {
            Damaged(0.5f, null);
        }
    }

    public void Damaged(float damage, Collider2D collider)
    {
        if (collider != null)
        {
            Destroy(collider.gameObject);
        }
        sr.material = WhiteMat;
        EnemyHP--;
        
        
        if (EnemyHP == 0)
        {
            audioManager.Explosound();
            sr.material = DefaultMat;
            Destroyed();
        }
        else
        {
            Invoke("ResetMaterial", 0.06f);
        }
    }
    private void ResetMaterial()
    {
        sr.material = DefaultMat;
    }
}
