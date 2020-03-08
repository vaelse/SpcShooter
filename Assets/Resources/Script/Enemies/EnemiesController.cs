﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
   public GameObject[] SpawnPosition;
    private float SpawnRate = 2f;
    private float NextSpawn;
    public int MaxEnemies = 0;
    private readonly int EnemiesLimit = 2;
    private int MaxKillcount = 10;
    GameManager killcount;

    private void Start()
    {
        killcount = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnKamii", 10f, 15f);
        InvokeRepeating("SpawnKamii", 10.1f, 15f);
        InvokeRepeating("SpawnKamii", 10.2f, 15f);

        InvokeRepeating("SpawnKamii2", 20f, 10f);
        InvokeRepeating("SpawnKamii2", 20.1f, 10f);
        InvokeRepeating("SpawnKamii2", 20.2f, 10f);

    }
    void Update()
    {
      
        if (MaxEnemies < EnemiesLimit)
        {
            RandomizeEnemies();          
        }
        
        
    }
  
    public void SpawnKamii()
    {
        if (killcount.killCount <= MaxKillcount)
        {
            EnemiesSpawner enemy;
            enemy = EnemiesSpawner.GetNewKami();
            SpawnKami(enemy, SpawnPosition[3]);
        }
    }
    public void SpawnKamii2()
    {
        if (killcount.killCount <= MaxKillcount)
        {
            EnemiesSpawner enemy;
            enemy = EnemiesSpawner.GetNewKami2();
            SpawnKami(enemy, SpawnPosition[4]);
        }
    }
   
    public void RandomizeEnemies()
    {
        if (killcount.killCount <= MaxKillcount)
        {
            var RandomEnemy = Random.value;
            if (Time.time > NextSpawn)
            {
                EnemiesSpawner enemy;

                if (RandomEnemy >= 0.5f)
                {
                    enemy = EnemiesSpawner.GetNewRed();
                    MaxEnemies++;
                }
                else
                {
                    enemy = EnemiesSpawner.GetNewBlue();
                    MaxEnemies++;
                }

                SpawnNewEnemy(enemy);
                NextSpawn = Time.time + SpawnRate;

            }
        }
    }

    public void SpawnNewEnemy(EnemiesSpawner enemy,GameObject SpawnArea = null)
    {
          //var RandomSpawn = Random.Range(0, 3);
          SpawnArea = this.SpawnPosition[Random.Range(0, 3)];

        Vector3 SpawnPosition = SpawnArea.transform.position;
        enemy.transform.position = SpawnPosition;
    }
   
    public void SpawnKami(EnemiesSpawner enemy, GameObject SpawnArea = null)
    {   
        enemy.transform.position = SpawnArea.transform.position;
    }

    
}