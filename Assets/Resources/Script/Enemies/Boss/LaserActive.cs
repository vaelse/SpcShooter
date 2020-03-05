using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActive : MonoBehaviour
{
    public GameObject Laser;
    private void Update()
    {
  
        if(gameObject.transform.rotation.eulerAngles.z != 90)
        {
            Laser.SetActive(true);
        }
        else
        {
            Laser.SetActive(false);
        }
    }
}
