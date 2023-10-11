using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    CharacterMovement characterMovement;
    [SerializeField] GameObject player;

    public bool gameStarted;
    public TextMeshProUGUI scoreText;    
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI endGameScoreText;
    public TextMeshProUGUI endGameHighscoreText;
    public float characterSpeed;
    public int score;
    public int highscore;

    void Awake()
    {
        characterMovement = player.GetComponent<CharacterMovement>();        
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
