using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private CharacterMovement characterMovement;
    
    [SerializeField] GameObject player;
    [SerializeField] public bool gameStarted;
    [SerializeField] private TextMeshProUGUI scoreText;    
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [SerializeField] private TextMeshProUGUI endGameHighscoreText;
    [SerializeField] private float characterSpeed;
    [SerializeField] private int score;
    [SerializeField] private int highscore;

    void Awake()
    {
        characterMovement = player.GetComponent<CharacterMovement>();

        highScoreText.text = highscore.ToString();
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }
    private void Update()
    {
        characterSpeed = characterMovement.speed;
    }
    public void StartGame()
    {        
        gameStarted = true;       
        scoreText.text = score.ToString();
        endGameScoreText.text = score.ToString();
        endGameHighscoreText.text = highscore.ToString();
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
        if(score % 5 == 0) // function that adds speed each time character gains 5 points
        {            
            float addSpeed = 1.1f;            
            float currentSpeed = characterSpeed * addSpeed;
            characterMovement.speed = currentSpeed;
        }
        if (highscore < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
    }
}
