using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]  public Slider volumeslider;
    [SerializeField] public Slider difficultSlider;

    
    void Start()
    {
        volumeslider.value = SaveManager.GetMasterVolume();
        difficultSlider.value = SaveManager.GetDifficulty();
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

        SaveManager.SetDifficulty(difficultSlider.value);

    }

  
}
