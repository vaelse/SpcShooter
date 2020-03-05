using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float BoostSpeed = 500;
   



    private void FixedUpdate()
    {      
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {                    
            this.transform.Translate(Vector3.right * BoostSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {                   
            this.transform.Translate(Vector3.left * BoostSpeed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.up *BoostSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(-Vector3.up *BoostSpeed * Time.deltaTime);
        }

    }

   

}
