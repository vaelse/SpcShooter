using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTurret : MonoBehaviour
{

    public float RepeatTiming;
    public float BulletSpeed;
    public GameObject Projectile;
    public Transform ProjectileSpawn;

    private void Start()
    {
       
        InvokeRepeating("Shoot", 2f, RepeatTiming);
    }

    public void Shoot()
    {
        var Bullet = Instantiate(Projectile, gameObject.transform.position, Quaternion.Euler(0, 0, 70));

        Bullet.transform.parent = GameObject.Find("Bullets").transform;
      
        Rigidbody2D Projectilerb = Bullet.GetComponent<Rigidbody2D>();
        Projectilerb.AddForce(transform.up * BulletSpeed);
        Destroy(Bullet, 2f);
    }
}
