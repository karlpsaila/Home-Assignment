using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction - new Vector2(1,0);

    [SerializeField] protected float speed - 2;

    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private


}
