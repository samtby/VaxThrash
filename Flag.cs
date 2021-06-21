using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
         public SpriteRenderer greenFlag;
         public SpriteRenderer redFlag;

        

    void Start()
    {
        greenFlag.color = new Color(1f, 1f, 1f, 0f);
        redFlag.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            redFlag.color = new Color(1f, 1f, 1f, 0f);
            greenFlag.color = new Color(1f, 1f, 1f, 1f);
            //chrono.StopChrono();
        }    
    }
}
