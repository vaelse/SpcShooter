using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
       
            transform.up = Player.position - transform.position;
        
    }
}
