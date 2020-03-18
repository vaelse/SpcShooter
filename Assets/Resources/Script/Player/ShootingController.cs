using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public GameObject Laser;
    public float attackSpeed;
    public float bulletSpeed;
    float nextShot = 0;
    int spawnIndex = 0;
    public GameObject redBullets;
    public GameObject blueBullets;
    public Transform[] spawnPosition;
    GameObject blletColor = null;
    public Image imageComponent;

    public AudioSource playerAudioSource;
    public AudioSource playerLaserSound;
    public AudioClip shootingSound;
    public AudioClip laserSound;
    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        blletColor = redBullets;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            blletColor = redBullets;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            blletColor = blueBullets;
        }
        else if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
            {
            playerAudioSource.PlayOneShot(shootingSound);
            Shooting(blletColor);
            }

        if (imageComponent.fillAmount == 0 || Input.GetKeyUp(KeyCode.X))
        {
            ShootingLaser(false);
        }
        if (Input.GetKey(KeyCode.X) && imageComponent.fillAmount >= 0)
        {
            if (!playerAudioSource.isPlaying)
            {
                playerAudioSource.PlayOneShot(laserSound);
                playerAudioSource.Play();
            }
            imageComponent.fillAmount -= Time.deltaTime * 0.5f;
            ShootingLaser(true);
        }
       else if (Input.GetKeyUp(KeyCode.X) || imageComponent.fillAmount == 0)
        {
            playerAudioSource.Stop();
        }
    }

    public void Shooting(GameObject bullet)
    {       
        nextShot = Time.time + attackSpeed;
        var Bullets = Instantiate(bullet) as GameObject;
        Bullets.transform.parent = GameObject.Find("Bullets").transform;

        Bullets.transform.position = spawnPosition[spawnIndex].position;
        spawnIndex++;

        if (spawnIndex >= 2)
            spawnIndex = 0;
        

        var BulletRigid = Bullets.GetComponent<Rigidbody2D>();
        BulletRigid.AddForce(-transform.up * bulletSpeed);      
        Destroy(Bullets, 2f);
    }

    public void ShootingLaser(bool active)
    {
        Laser.SetActive(active);   
    }
}
