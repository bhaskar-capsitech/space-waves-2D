using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int highScore = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    void Awake()
    {
        // Singleton pattern for easy access
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount;
        UpdateScoreUI();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "Best Score: " + highScore.ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
}

