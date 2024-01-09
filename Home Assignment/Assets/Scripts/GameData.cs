using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;


public class GameData : MonoBehaviour
{

    private static int _playerhealth = 150;
    private static int _score = 0;
    private static int _kills = 0;
    public static int _HighScore;


    public static int PlayerHealth
    {
        get { return _playerhealth; }
        set { _playerhealth = value; }

    }

    public static int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public static int Kills
    {
        get { return _kills; }
        set { _kills = value; }
    }


    public static int HighScore
    {
        get { return _HighScore; }
        set { _HighScore = value; }
    }

    private static float _padding = 1f;

    Camera gameCamera = Camera.main;

    public static float Xmin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding; }
    }

    public static float Xmax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding; }
    }

    public static float Ymin
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding; }
    }

    public static float Ymax
    {
        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding; }
    }

   
}
