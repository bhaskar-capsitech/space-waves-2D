using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomePageManager : MonoBehaviour
{
    public Button startButton;
    public TMP_Text bestScoreText; 

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (bestScoreText != null)
            bestScoreText.text = "Best Score: " + highScore.ToString();

        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SpaceWaves");
    }
}
