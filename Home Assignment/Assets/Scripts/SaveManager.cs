using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager
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

    public void SaveData()
    {
        SerializedData mySerializedData = new SerializedData();
        mySerializedData.ser_score = GameData.Score;
        mySerializedData.ser_lives = GameData.PlayerHealth;
        mySerializedData.ser_kills = GameData.Kills;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream myfile = File.Create(Application.persistentDataPath + "/CannonData.save");
        Debug.Log(Application.persistentDataPath.ToString());
        bf.Serialize(myfile, mySerializedData);  //Serialize and save
        myfile.Close();
        Debug.Log("FILE SAVED");

    }

    public void LoadData()
    {
        SerializedData mySerializedData = new SerializedData();

        if (File.Exists(Application.persistentDataPath + "/CannonData.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream myfile = File.Open(Application.persistentDataPath + "/CannonData.save", FileMode.Open);
            mySerializedData = (SerializedData)bf.Deserialize(myfile);
            myfile.Close();

            GameData.Score = mySerializedData.ser_score;
            GameData.PlayerHealth = mySerializedData.ser_lives;
            GameData.Kills = mySerializedData.ser_kills;
        }

    }

    public void DeleteFile()
    {
        if (File.Exists(Application.persistentDataPath + "/CannonData.save"))
        {
            File.Delete(Application.persistentDataPath + "/CannonData.save");
        }

    }
}
