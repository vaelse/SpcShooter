using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    

    public static EnemiesSpawner GetNewRed()
    {

        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/RedEnemies"));        
        return enemy.GetComponent<EnemiesSpawner>();
        
    }
    public static EnemiesSpawner GetNewBlue()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/BlueEnemies"));
        return enemy.GetComponent<EnemiesSpawner>();
        
    }
    public static EnemiesSpawner GetNewKami()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Kamikkaze"));
        return enemy.GetComponent<EnemiesSpawner>();

    }
    public static EnemiesSpawner GetNewKami2()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Kamikkaze2"));
        return enemy.GetComponent<EnemiesSpawner>();
    }

}
