using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(false);
        gameManager.StartGame();
    }

    public void Settings()
    {
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void MainMenu()
    {
        SettingsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void OnApplicationQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();
        #endif
    }
}
