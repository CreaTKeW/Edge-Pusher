using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private CharacterMovement characterMovement;
    
    [SerializeField] GameObject player;
    [SerializeField] public bool gameStarted;

    [Header("Scoreboard Text")]
    [SerializeField] private TextMeshProUGUI scoreText;    
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [SerializeField] private TextMeshProUGUI endGameHighscoreText;

    [Header("Scoreboard")]
    [SerializeField] private int score;
    [SerializeField] private int highscore;

    void Awake()
    {
        characterMovement = player.GetComponent<CharacterMovement>();
        highscore = PlayerPrefs.GetInt("ZombieRunnerHighscore", 0);
        highScoreText.text = highscore.ToString();
    }

    public void StartGame()
    {        
        scoreText.text = score.ToString();        
        endGameScoreText.text = score.ToString();
        endGameHighscoreText.text = highscore.ToString();
        gameStarted = true;
    }

    public void EndGame()
    {
        gameStarted = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        endGameScoreText.text = score.ToString();

        if (characterMovement.speed < 5)
        {
            if (score % 5 == 0) 
            {
                characterMovement.speed += 0.25f;
            }
        }

        if (highscore < score)
        {
            PlayerPrefs.SetInt("ZombieRunnerHighscore", score);
        }
    }
}
