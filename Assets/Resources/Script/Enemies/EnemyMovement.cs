using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{  
    public float movementSpeed = 20;
    public GameObject[] Points;
    private int RandomPoints;
    private float RandomWaitTime;
    private float waitTime = 0;

    private void Start()
    {
        transform.Rotate(0, 0, 90);
        RandomPoints = Random.Range(0, Points.Length);
        RandomWaitTime = Random.value;
    }

    private void FixedUpdate()
    {             
       transform.position = Vector2.MoveTowards(transform.position, Points[RandomPoints].transform.position, movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Points[RandomPoints].transform.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                RandomPoints = Random.Range(0, Points.Length);
                waitTime = RandomWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }                 
        }
    }
}
