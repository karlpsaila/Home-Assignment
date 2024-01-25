using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    const string Master_Volume_Key = "master volume";
    const string Difficulty_Key = "difficulty";

    public static void SetMasterVolume(float volume)
    {

        if (volume >= GameData.Min_Volume && volume <= GameData.Max_Volume)
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(Master_Volume_Key, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
        PlayerPrefs.SetFloat(Master_Volume_Key, volume);
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(Master_Volume_Key);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= GameData.Min_Difficulty && difficulty <= GameData.Max_Difficulty)
        {
            Debug.Log("Difficulty set to " + difficulty);
            PlayerPrefs.SetFloat(Difficulty_Key, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(Difficulty_Key);
    }

}
