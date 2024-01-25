using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text HighScore;

    [SerializeField] Text kills;
    [SerializeField] Text MostKills;



    void Start()
    {


        if (PlayerPrefs.HasKey("HighScore"))
        {
            GameData.HighScore = PlayerPrefs.GetInt("HighScore");
        }

        if (PlayerPrefs.HasKey("MostKills"))
        {
            GameData.Kills = PlayerPrefs.GetInt("MostKills");
        }

    }

    void Update()
    {
        if (GameData.Score > GameData.HighScore)
        {
            GameData.HighScore = GameData.Score;
            PlayerPrefs.SetInt("HighScore", GameData.HighScore);
            PlayerPrefs.Save();
        }
        if (GameData.Kills > GameData.MostKills)
        {
            GameData.MostKills = GameData.Kills;
            PlayerPrefs.SetInt("MostKills", GameData.MostKills);
            PlayerPrefs.Save();
        }

        scoreText.text = "Score: " + GameData.Score;
        HighScore.text = "High Score: " + GameData.HighScore;

        kills.text = "Kills: " + GameData.Kills;
        if(SceneManager.GetActiveScene().name == "Game Over")
        {
            MostKills.text = "MostKills: " + GameData.MostKills;

        }
       

        
    }

}
