using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource audios;
    public AudioClip exploclip;

    public void Explosound()
    {
        audios.PlayOneShot(exploclip);
    }
}
