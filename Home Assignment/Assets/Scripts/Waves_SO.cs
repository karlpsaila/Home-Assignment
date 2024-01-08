using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Wave", menuName = "ScriptableObject/Wave", order = 1)]

public class Waves_SO : ScriptableObject
{
    [field: SerializeField]

    public GameObject[] EnemiesInWave { get; set; }
    [field: SerializeField]

    public float TimeBetweenSpawns { get; set; }

    [field: SerializeField]
    public float NumberToSpawn { get; set; }
}
