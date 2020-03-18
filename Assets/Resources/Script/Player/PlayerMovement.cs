using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float boostSpeed = 500;
   
    private void FixedUpdate()
    {      
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {                    
            transform.Translate(Vector3.right * boostSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {                   
            transform.Translate(Vector3.left * boostSpeed * Time.deltaTime);
        }           
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.up *boostSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-Vector3.up *boostSpeed * Time.deltaTime);
        }
    }
}
