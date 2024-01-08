using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charged : Bullet
{

    void Start()
    {
        Destroy(gameObject, 35);
    }

    void Update()
    {
        velocity = direction.normalized * speed;
    }

     void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }


    public void SetProperties(Vector2 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}
