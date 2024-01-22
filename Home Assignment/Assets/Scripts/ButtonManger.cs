using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManger : MonoBehaviour
{
    [SerializeField] List<Button> buttons; // List of buttons

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in buttons)
        {
            // Assuming button names are "Start" and "Exit" for respective functionality
            if (button.name == "Play")
            {
                button.onClick.AddListener(StartGame);
            }
            else if (button.name == "Exit")
            {
                button.onClick.AddListener(QuitGame);
            }
            else if (button.name == "Settings")
            {
                button.onClick.AddListener(Settings);
            }
            else
            {
                Debug.Log("Button name not found");
            }

            // Add a generic listener for all buttons
            button.onClick.AddListener(() => PrintMsg(button.name));
        }
    }

    void StartGame()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene("Level1");
    }

    void QuitGame()
    {
        Debug.Log("You have clicked the exit button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        ApplicatKion.Quit();
#endif
    }

    void Settings()
    {
        Debug.Log("Openning Settings");
        SceneManager.LoadScene("Settings");
    }
    

    void PrintMsg(string buttonName)
    {
        Debug.Log(buttonName + " has been clicked");
    }
}
