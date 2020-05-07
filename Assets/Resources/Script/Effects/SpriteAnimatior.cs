using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimatior : MonoBehaviour
{
   [SerializeField] private Sprite[] SpriteFrames;
    private int CurrentFrame;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >=0.05f)
        {
            timer -= 0.05f;
            CurrentFrame = (CurrentFrame+1)%SpriteFrames.Length;
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFrames[CurrentFrame];
        }    
    }
}
