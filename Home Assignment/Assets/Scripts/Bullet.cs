using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector2 direction = new Vector2(0,1);
    public float speed = 5f;

    public Vector2 velocity;

    void Start()
    {
        Destroy(gameObject, 5);
    }
   
    void Update()
    {
        velocity = direction.normalized * speed;
    }

    protected void FixedUpdate()
    {
       Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the current GameObject has the tag "Bullet"
        if (gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
