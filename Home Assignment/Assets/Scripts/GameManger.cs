using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Text scoreText;
    public Text HighScore;

    void Start()
    {
       if (PlayerPrefs.HasKey("HighScore"))
        {
            GameData.HighScore = PlayerPrefs.GetInt("HighScore");
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

        scoreText.text = "Score: " + GameData.Score;
        HighScore.text = "High Score: " + GameData.HighScore;

    }
}
