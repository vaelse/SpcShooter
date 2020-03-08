using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    

    public static EnemiesSpawner GetNewRed()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/RedEnemies"));        
        return enemy.GetComponent<EnemiesSpawner>();       
    }
    public static EnemiesSpawner GetNewBlue()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/BlueEnemies"));
        return enemy.GetComponent<EnemiesSpawner>();       
    }
    public static EnemiesSpawner GetNewKami()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Kamikkaze"));
        return enemy.GetComponent<EnemiesSpawner>();
    }
    public static EnemiesSpawner GetNewKami2()
    {
        var enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Kamikkaze2"));
        return enemy.GetComponent<EnemiesSpawner>();
    }

}
