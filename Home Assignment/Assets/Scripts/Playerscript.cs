using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    
    public Rigidbody2D rb;

    [SerializeField] float movespeed = 5f;
    [SerializeField] float boost = 2.0f;   // Boost multiplier

    private float boostDuration = 1.0f;    // Duration of the boost in seconds
    private float boostCooldown = 3.0f;    // Cooldown period in seconds
    private float boostTimer = 0.0f;       // Timer to track the remaining boost time
    private float cooldownTimer = 0.0f;


    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        
        move();

    }

    void move()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * movespeed;
        float moveY = Input.GetAxis("Vertical") * Time.fixedDeltaTime * movespeed;

        // Update boost and cooldown timers
        if (boostTimer > 0.0f)
        {
            boostTimer -= Time.fixedDeltaTime;

            // Check if boost duration has ended
            if (boostTimer <= 0.0f)
            {
                boostTimer = 0.0f;
                rb.velocity /= boost;
            }
        }

        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) && cooldownTimer <= 0.0f)
        {
            // Start boost
            boostTimer = boostDuration;
            rb.velocity *= boost;  
            
            cooldownTimer = boostCooldown;
        }

        // Apply boost if the boost duration is active
        float boostMultiplier = (boostTimer > 0.0f) ? boost : 1.0f;

        float Xpos = Mathf.Clamp(transform.position.x + moveX * boostMultiplier, GameData.Xmin, GameData.Xmax);
        float Ypos = Mathf.Clamp(transform.position.y + moveY * boostMultiplier, GameData.Ymin, GameData.Ymax);

        transform.position = new Vector2(Xpos, Ypos);
    }





}
