using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float RepeatTiming; 
    public float BulletSpeed;
    private int ProjectileIndex;
    public GameObject Projectile;
    public Transform[] ProjectileSpawn;

    private void Start()
    {   
    InvokeRepeating("Shoot", Random.value, RepeatTiming);
    }

    public void Shoot()
    {      
        var Attack = GameObject.Instantiate(Projectile) as GameObject;
        Attack.transform.parent = GameObject.Find("Bullets").transform;
        Attack.transform.position = ProjectileSpawn[ProjectileIndex].position;
        ProjectileIndex++;
        if (ProjectileIndex >= ProjectileSpawn.Length)
            ProjectileIndex = 0;
        
        //var Projectilerb = Attack.GetComponent<Rigidbody2D>();
        Attack.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletSpeed);
        Destroy(Attack, 3f);
    }
}
