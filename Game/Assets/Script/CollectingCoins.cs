using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    void Start()
    {
        Collider2D c;
        if (!GetComponent<Collider2D>())
        {
            c = gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            c = GetComponent<Collider2D>();
        }
        c.isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        Destroy(gameObject,0.5f);
        Debug.Log("Coins!!");
    }
}
