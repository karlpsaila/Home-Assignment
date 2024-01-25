using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    Gun[] guns;

    public charged chargedshot1;
    private bool canShoot = true;
    public Rigidbody2D rb;

    [SerializeField] float movespeed = 5f;
    [SerializeField] float boost = 2.0f;
    private float boostDuration = 1.0f;
    private float boostCooldown = 3.0f;
    private float boostTimer = 0.0f;
    private float cooldownTimer = 0.0f;

    Coroutine myFiringCoroutine1;

    [SerializeField] float bulletFiringPeriod;
    private float maxHealth;
    public Image healthBar;

    public AudioClip shootingSound; // Reference to the shooting sound

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        guns = GetComponentsInChildren<Gun>();
        maxHealth = GameData.PlayerHealth;

        if(SaveManager.GetDifficulty() == 1)
        {
            GameData.PlayerHealth = 100;
            Debug.Log("Difficulty set to " + SaveManager.GetDifficulty());
            Debug.Log("Health set to " + GameData.PlayerHealth);
        }
        else if (SaveManager.GetDifficulty() == 2)
        {
            GameData.PlayerHealth = 50;
        }

    }

    void Update()
    {
        HandleShooting();
        Chargedshot();
        Countdown();
        GameOver();

        
        UpdateHealthBar();
    }

    void FixedUpdate()
    {
       
        MovePlayer();
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (myFiringCoroutine1 == null)
            {
                myFiringCoroutine1 = StartCoroutine(FireContinuously());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(myFiringCoroutine1);
            myFiringCoroutine1 = null;
        }
    }

    void Countdown()
    {
        if (!canShoot)
        {
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(5);
        canShoot = true;
    }


    void Chargedshot()
    {
        if (Input.GetMouseButtonDown(1) && canShoot)
        {
            charged newChargedShot = Instantiate(chargedshot1, transform.position, Quaternion.identity);
            newChargedShot.SetProperties(transform.position, Quaternion.identity);

            canShoot = false; // Prevent shooting until countdown is complete
            StopAllCoroutines(); // Reset the countdown timer
            StartCoroutine(StartCountdown()); // Start the countdown again
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * movespeed;
        float moveY = Input.GetAxis("Vertical") * Time.fixedDeltaTime * movespeed;

        if (boostTimer > 0.0f)
        {
            boostTimer -= Time.fixedDeltaTime;

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
            boostTimer = boostDuration;
            rb.velocity *= boost;
            cooldownTimer = boostCooldown;
        }

        float boostMultiplier = (boostTimer > 0.0f) ? boost : 1.0f;

        float Xpos = Mathf.Clamp(transform.position.x + moveX * boostMultiplier, GameData.Xmin, GameData.Xmax);
        float Ypos = Mathf.Clamp(transform.position.y + moveY * boostMultiplier, GameData.Ymin, GameData.Ymax);

        transform.position = new Vector2(Xpos, Ypos);
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            foreach (Gun gun in guns)
            {
                gun.shoot();
                
            }
            PlayShootingSound();
            yield return new WaitForSeconds(bulletFiringPeriod);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>();


        if (other.gameObject.tag == "Enemy")
        {
            int enemyStrength = enemyScript._strength;
            GameData.PlayerHealth -= enemyStrength;
            Destroy(other.gameObject);

            Debug.Log("Health " + GameData.PlayerHealth.ToString());
        }
        else if (other.gameObject.tag == "EnemyBullet")
        {

           int randomDamge = Random.Range(2, 13);

            GameData.PlayerHealth -= randomDamge;
            Debug.Log("Health " + GameData.PlayerHealth.ToString());

        }
        else if (other.gameObject.tag == "Boss1")
        {
            int randomDamge = Random.Range(10, 15);

            GameData.PlayerHealth -= randomDamge;
            Debug.Log("Health " + GameData.PlayerHealth.ToString());
        }
        else if (other.gameObject.tag == "Boss2")
        {
            int randomDamge = Random.Range(15, 20);

            GameData.PlayerHealth -= randomDamge;
            Debug.Log("Health " + GameData.PlayerHealth.ToString());
        }
    }

        void GameOver()
        {
            if (GameData.PlayerHealth <= 0)
            {
                SceneManager.LoadScene("GameOver");
                //var gameManager = FindObjectOfType<GameManager>();
                //mySaveLoadManager.SaveData();
                //mySaveLoadManager.DeleteFile();
                
            }
        }


    public void UpdateHealthBar()
    {

        float fillAmount = Mathf.Clamp(GameData.PlayerHealth / maxHealth, 0, 1);
       
        healthBar.fillAmount = fillAmount;

    }

    void PlayShootingSound()
    {
        // Check if the audio source and sound are assigned
        if (audioSource != null && shootingSound != null)
        {
            // Play the shooting sound
            audioSource.PlayOneShot(shootingSound);
        }
    }
}
