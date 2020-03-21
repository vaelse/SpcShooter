using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.up = Player.position - transform.position;
        }
    }
}
