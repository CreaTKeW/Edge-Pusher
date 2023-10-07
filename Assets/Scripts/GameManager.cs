using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public TextMeshProUGUI scoreText;    
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI endGameScoreText;
    public TextMeshProUGUI endGameHighscoreText;
    public int score;
    public int highscore;

    public void Start()
    {      
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        Debug.Log("Highscore: " + highscore);
    }
    public void StartGame()
    {        
        gameStarted = true;       
        scoreText.text = score.ToString();
        endGameScoreText.text = score.ToString();
        highScoreText.text = highscore.ToString();
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
        if (highscore < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
    }
}
