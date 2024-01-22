using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] Text scoreText;
    [SerializeField] Text HighScore;

    SaveManager mySaveLoadManager;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            mySaveLoadManager = new SaveManager();
            GameData.HighScore = PlayerPrefs.GetInt("HighScore");
            mySaveLoadManager.LoadData();
        }

        mySaveLoadManager = new SaveManager();
        GameData.PlayerHealth = 20;
        mySaveLoadManager.LoadData();


    }

    public void OnEnemyDie(int hitpoints)
    {

        GameData.Score += hitpoints;
        Destroy(this.gameObject);
        GameData.PlayerHealth += 10;
        GameData.Kills += 1;

        Playerscript playerScript = FindObjectOfType<Playerscript>();
        if (playerScript != null)
        {
            playerScript.UpdateHealthBar();
        }
        mySaveLoadManager.SaveData();
    }

    void Update()
    {
        if (GameData.Score > GameData.HighScore)
        {
            GameData.HighScore = GameData.Score;
            PlayerPrefs.SetInt("HighScore", GameData.HighScore);
            PlayerPrefs.Save();
        }

        scoreText.text = "Score: " + GameData.Score;
        HighScore.text = "High Score: " + GameData.HighScore;

    }

    public void PlayerDamage()
    {
        mySaveLoadManager.SaveData();
        if (GameData.PlayerHealth <= 0)
        {
            mySaveLoadManager.DeleteFile();
            SceneManager.LoadScene("GameOver");
        }

    }

}
