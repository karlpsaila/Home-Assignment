using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]  public Slider volumeslider;
    [SerializeField] float defaultVolume = 0.8f;

    
    void Start()
    {
        volumeslider.value = SaveManager.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeslider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

  
}
