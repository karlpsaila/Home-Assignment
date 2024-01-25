using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManger : MonoBehaviour
{
    [SerializeField] List<Button> buttons; // List of buttons

    public Animator transiction;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in buttons)
        {
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
            else if (button.name == "Reset")
            {
                button.onClick.AddListener(MainMenu);
            }
            else if (button.name == "Back")
            {
                button.onClick.AddListener(Back);
            }
            else
            {
                Debug.Log("Button name not found");
            }

            // Add a generic listener for all buttons
            button.onClick.AddListener(() => PrintMsg(button.name));

            // Log a message to check if the listener is added
            Debug.Log("Listener added for button: " + button.name);
        }
    }


    void StartGame()
    {
        Debug.Log("You have clicked the start button");
        StartCoroutine(LoadScene());

    }

    void QuitGame()
    {
        Debug.Log("You have clicked the exit button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#endif
    }

    void Settings()
    {
        Debug.Log("Openning Settings");
        SceneManager.LoadSceneAsync("Settings");
    }
    
    void MainMenu()
    {
       
        Debug.Log("Openning Main Menu");
        SceneManager.LoadScene("StartScreen");


    }

    void Back()
    {
        Options optionsInstance = FindObjectOfType<Options>();
        SaveManager.SetMasterVolume(optionsInstance.volumeslider.value);
        Debug.Log("Openning Main Menu");
        SceneManager.LoadScene("StartScreen");


    }

    void PrintMsg(string buttonName)
    {
        Debug.Log(buttonName + " has been clicked");
    }


    IEnumerator LoadScene()
    {
        


        transiction.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Level1");
    }

    //SceneManager.LoadSceneAsync("Level1");
}
