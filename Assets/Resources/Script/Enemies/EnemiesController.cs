using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
   public GameObject[] SpawnPosition;
    private float spawnRate = 2f;
    private float nextSpawn;
    public int maxEnemies = 0;
    private int enemiesLimit = 2;
    private int maxKillCount = 8;
    GameManager killCount;

    private void Start()
    {
        killCount = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnKamii", 10f, 15f);
        InvokeRepeating("SpawnKamii", 10.1f, 15f);
        InvokeRepeating("SpawnKamii", 10.2f, 15f);

        InvokeRepeating("SpawnKamii2", 20f, 10f);
        InvokeRepeating("SpawnKamii2", 20.1f, 10f);
        InvokeRepeating("SpawnKamii2", 20.2f, 10f);
    }
    void Update()
    {    
        if (maxEnemies < enemiesLimit)
        {
            RandomizeEnemies();          
        }      
    }
  
    public void SpawnKamii()
    {
        if (killCount.killCount <= maxKillCount)
        {
            EnemiesSpawner enemy;
            enemy = EnemiesSpawner.GetNewKami();
            SpawnKami(enemy, SpawnPosition[3]);
        }
    }
    public void SpawnKamii2()
    {
        if (killCount.killCount <= maxKillCount)
        {
            EnemiesSpawner enemy;
            enemy = EnemiesSpawner.GetNewKami2();
            SpawnKami(enemy, SpawnPosition[4]);
        }
    }
   
    public void RandomizeEnemies()
    {
        if (killCount.killCount <= maxKillCount)
        {
            var RandomEnemy = Random.value;
            if (Time.time > nextSpawn)
            {
                EnemiesSpawner enemy;

                if (RandomEnemy >= 0.5f)
                {
                    enemy = EnemiesSpawner.GetNewRed();
                    maxEnemies++;
                }
                else
                {
                    enemy = EnemiesSpawner.GetNewBlue();
                    maxEnemies++;
                }
                SpawnNewEnemy(enemy);
                nextSpawn = Time.time + spawnRate;
            }
        }
    }

    public void SpawnNewEnemy(EnemiesSpawner enemy,GameObject SpawnArea = null)
    {
        SpawnArea = this.SpawnPosition[Random.Range(0, 3)];
        Vector3 SpawnPosition = SpawnArea.transform.position;
        enemy.transform.position = SpawnPosition;
    }
   
    public void SpawnKami(EnemiesSpawner enemy, GameObject SpawnArea = null)
    {   
        enemy.transform.position = SpawnArea.transform.position;
    }

    
}
