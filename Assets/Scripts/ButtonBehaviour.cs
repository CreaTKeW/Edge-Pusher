using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject EndGameUI;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();       
    }

    void Start()
    {        
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);              
        EndGameUI.SetActive(false);
    }

    private void StartGame()
    {
        gameManager.StartGame();
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(false);
        FindObjectOfType<Road>().RoadBuild();
    }

    private void Settings()
    {
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    private void MainMenu()
    {
        SettingsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnApplicationQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();
        #endif
    }
}
