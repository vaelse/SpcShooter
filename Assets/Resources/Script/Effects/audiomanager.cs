using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource audios;
    public AudioClip explosionclip;

    public void Explosound()
    {
        audios.PlayOneShot(explosionclip);
    }
}
