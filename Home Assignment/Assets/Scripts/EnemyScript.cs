using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
        _strength = start_strength;
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

        if (transform.position.y < -18)
        {
            Destroy(gameObject);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Bullet")
        {
         GetComponent<ITakeDamage>().ApplyDamage(hitpoints, false);
        }
        else if (other.gameObject.tag == "charged")
        {
        GetComponent<ITakeDamage>().ApplyDamage(hitpoints, true);
        }
    }


    void shoot()
    {
       if (SceneManager.GetActiveScene().name == "StartScreen")
        {

        }
       else
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
        }

    }

    void OnDestroy()
    {
        if (gameObject.tag == "Boss1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (gameObject.tag == "Boss2")
        {
            SceneManager.LoadScene("Win");
        }
    }


}
