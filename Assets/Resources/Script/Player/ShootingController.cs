using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public GameObject Laser;
    public float AttackSpeed;
    public float BulletSpeed;
    float NextShot = 0;
    int SpawnIndex = 0;
    public GameObject RedBullets;
    public GameObject BlueBullets;
    public Transform[] SpawnPosition;
    GameObject BulletColor = null;
    public Image ImageComponent;

    public AudioSource playerAudioSource;
    public AudioClip shootingSound;
    public AudioClip laserSound;
    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        BulletColor = RedBullets;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            BulletColor = RedBullets;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            BulletColor = BlueBullets;
        }
        else if (Input.GetKey(KeyCode.Space) && Time.time > NextShot)
            {
            playerAudioSource.PlayOneShot(shootingSound);
            Shooting(BulletColor);
            }

        if (ImageComponent.fillAmount == 0 || Input.GetKeyUp(KeyCode.X))
        {
            
            ShootingLaser(false);
        }
        else if (Input.GetKey(KeyCode.X) && ImageComponent.fillAmount >= 0)
        {
            ImageComponent.fillAmount -= Time.deltaTime * 0.5f;
            ShootingLaser(true);           
        }
        
    }

    public void Shooting(GameObject bullet)
    {       
        NextShot = Time.time + AttackSpeed;
        var Bullets = Instantiate(bullet) as GameObject;
        Bullets.transform.parent = GameObject.Find("Bullets").transform;

        Bullets.transform.position = SpawnPosition[SpawnIndex].position;
        SpawnIndex++;

        if (SpawnIndex >= 2)
            SpawnIndex = 0;
        

        var BulletRigid = Bullets.GetComponent<Rigidbody2D>();
        BulletRigid.AddForce(-transform.up * BulletSpeed);      
        Destroy(Bullets, 2f);
    }

    public void ShootingLaser(bool active)
    {
        Laser.SetActive(active);   
    }
}
