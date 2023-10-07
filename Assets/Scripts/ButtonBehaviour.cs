using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    public GameObject EndGameUI;
    private GameManager gameManager;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        gameManager.highScoreText.text = gameManager.highscore.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {       
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);              
        EndGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        gameManager.StartGame();
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(false);      
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

    public void Restart()
    {
        SceneManager.LoadScene(0);
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
