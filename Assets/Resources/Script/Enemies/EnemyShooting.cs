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
        float AttackTiming = Random.value;
    InvokeRepeating("Shoot", AttackTiming, RepeatTiming);
    }

    public void Shoot()
    {
       
        GameObject Attack = GameObject.Instantiate(Projectile) as GameObject;
        Attack.transform.parent = GameObject.Find("Bullets").transform;
        Attack.transform.position = ProjectileSpawn[ProjectileIndex].position;
        ProjectileIndex++;
        if (ProjectileIndex >= ProjectileSpawn.Length)
            ProjectileIndex = 0;
        
        Rigidbody2D Projectilerb = Attack.GetComponent<Rigidbody2D>();
        Projectilerb.AddForce(transform.up * BulletSpeed);
        Destroy(Attack, 2f);
    }
}
