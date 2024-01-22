using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("charged"))
        {
            ITakeDamage takeDamageComponent = other.gameObject.GetComponent<ITakeDamage>();

            // Check if the component is not null before using it
            if (takeDamageComponent != null)
            {
                takeDamageComponent.ApplyDamage(hitpoints, true);
            }
            else
            {
                Debug.LogError("ITakeDamage component not found on the bullet or charged object.");
            }
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


}
