using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITakeDamage
{
    public void ApplyDamage(int hitpoints, bool isCharged);
}


public class EnemyScript : MonoBehaviour
{
    bool canbeDestroyed = false;

    public int hitpoints;
    public int start_strength;
    public float start_speed;

    public int _strength;

    public GameObject enemyBullet;

    protected float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 14f)
        {
            canbeDestroyed = true;
        }


        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0f;
            shoot();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canbeDestroyed)
        {
           return;
        }
        if (other.gameObject.tag == "Bullet")
        {
            // Example usage when hit by a regular item
            GetComponent<ITakeDamage>().ApplyDamage(hitpoints, false);

        }
        else if(other.gameObject.tag == "charged")
        {
            // Example usage when hit by a charged item
            GetComponent<ITakeDamage>().ApplyDamage(hitpoints, true);

        }


    }

    void shoot()
    {
       Instantiate(enemyBullet, transform.position, Quaternion.identity);

    }

}
