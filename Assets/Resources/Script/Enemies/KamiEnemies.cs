using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamiEnemies : MonoBehaviour
{
    public float EnemyHP = 5;
    private Material WhiteMat;
    private Material DefaultMat;
    SpriteRenderer sr;
    ScoreController score;
    public int KamiScore = 20;
    public int KamiScoreColor = 80;
    public GameObject HPBox;
    public GameObject LaserBox;
   
    private void Start()
    {
        var RandomColor = Random.value;
        sr = gameObject.GetComponent<SpriteRenderer>();
        WhiteMat = Resources.Load("Material/WhiteFlash", typeof(Material)) as Material;
        DefaultMat = sr.material;

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();

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
            Destroyed(collision, null, KamiScore,0.5f);
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
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "BossLazer")
        {
            EnemyHP -= 0.5f;
            sr.material = WhiteMat;
            if (EnemyHP == 0)
            {
                Destroy(gameObject);
                score.IncreaseScore(KamiScore);              
            }
            else
            {
                Invoke("ResetMaterial", 0.09f);
            }
        }
    }

    public void Destroyed (Collider2D bullet, GameObject Pickable , int killscore, float damage)
    {    
        sr.material = WhiteMat;
        EnemyHP -= damage;
        Destroy(bullet.gameObject);
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
            score.IncreaseScore(killscore);
            if (Pickable != null)
                InstantiatePickable(Pickable);
        }
        else
        {
            Invoke("ResetMaterial", 0.09f);
        }
    }
    void ResetMaterial()
    {
        sr.material = DefaultMat;
    }
}

