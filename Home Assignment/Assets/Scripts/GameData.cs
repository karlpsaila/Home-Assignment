using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class GameData : MonoBehaviour
{
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
