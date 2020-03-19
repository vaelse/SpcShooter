using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{   
    public static EnemiesSpawner GetNewRed()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Spaceships/RedEnemies"));        
        return enemy.GetComponent<EnemiesSpawner>();       
    }
    public static EnemiesSpawner GetNewBlue()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Spaceships/BlueEnemies"));
        return enemy.GetComponent<EnemiesSpawner>();       
    }
    public static EnemiesSpawner GetNewKami()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Spaceships/Kamikkaze"));
        return enemy.GetComponent<EnemiesSpawner>();
    }
    public static EnemiesSpawner GetNewKami2()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Spaceships/Kamikkaze2"));
        return enemy.GetComponent<EnemiesSpawner>();
    }
}
