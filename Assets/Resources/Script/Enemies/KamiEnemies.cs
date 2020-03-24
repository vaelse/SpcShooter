using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamiEnemies : MonoBehaviour
{
    private audiomanager audioManager; 
    public float EnemyHP = 3;

    private Material WhiteMat;
    private Material DefaultMat;
    SpriteRenderer sr;
    ScoreController score;
    public int KamiScore = 20;
    public int KamiScoreColor = 80;
    public GameObject HPBox;
    public GameObject LaserBox;
    public Animator animator;
    public GameObject pickable;

    private void Start()
    {      
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Assets/Materials/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();

        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<audiomanager>();

        colorRandomizer();
    }
    private void Update()
    {
        animator.SetFloat("Health", EnemyHP);
    }
    public void InstantiatePickable(GameObject Pickable)
    {
        var PickBox = Instantiate(Pickable, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        var Pickableitem = PickBox.GetComponent<Rigidbody2D>();
        Pickableitem.AddForce(-transform.up * 2f);      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (sr.color == Color.white && collision.gameObject.tag == "RedBullet")
        {
            Destroyed(collision, null, KamiScore,1);
        }
        else if (sr.color == Color.white && collision.gameObject.tag == "BlueBullet")
        {
            Destroyed(collision, null, KamiScore, 1);
        }
        else if ( sr.color == Color.blue && collision.gameObject.tag == "BlueBullet" )
        {
            Destroyed(collision, HPBox, KamiScoreColor,1);
        }
        else if (sr.color == Color.red && collision.gameObject.tag == "RedBullet" )
        {
            Destroyed(collision, LaserBox, KamiScoreColor, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(sr.color == Color.red)
        {
            pickable = LaserBox;
        }
        else if (sr.color == Color.blue)
        {
            pickable = HPBox;
        }
        else
        {
            pickable = null;
        }

        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "BossLazer")
        {
            Destroyed(null, pickable, KamiScore, 0.5f);
        }
    }

    public void Destroyed (Collider2D collider, GameObject Pickable , int killscore, float damage)
    {    
        sr.material = WhiteMat;
        EnemyHP -= damage;
        if (collider != null)
        {
            Destroy(collider.gameObject);
        }
        if (EnemyHP <= 0)
        {
            audioManager.Explosound();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            sr.material = DefaultMat;
            Destroy(gameObject,0.6f);
            score.IncreaseScore(killscore);
            if (Pickable != null)
                InstantiatePickable(Pickable);
        }
        else
        {
            Invoke("ResetMaterial", 0.02f);
        }
    }
    void ResetMaterial()
    {
        sr.material = DefaultMat;
    }

    public void colorRandomizer()
    {
        var RandomColor = Random.value;

        if (RandomColor < .1)
        {
            sr.color = Color.red;
        }
        else if (RandomColor > 0.1 && RandomColor < 0.2)
        {
            sr.color = Color.blue;
        }
        else
        {
            sr.color = Color.white;
        }
    }
}

