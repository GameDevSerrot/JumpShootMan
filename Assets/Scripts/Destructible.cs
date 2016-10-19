using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {
    public int health;

    void Start()
    {
        health = 2;
    }

    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }





    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            health--;
        }
    }
}


