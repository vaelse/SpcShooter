using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public float RepeatTiming;
    public float BulletSpeed;
    public GameObject Projectile;
    public Transform ProjectileSpawn;

    private void Start()
    {
        InvokeRepeating("Shoot", Random.value, RepeatTiming);
    }

    public void Shoot()
    {
        var Bullet = Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation);
        Bullet.transform.parent = GameObject.Find("Bullets").transform;

        var Projectilerb = Bullet.GetComponent<Rigidbody2D>();
        Projectilerb.AddForce(transform.up * BulletSpeed);
        Destroy(Bullet, 2f);
    }
}
