using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomePageManager : MonoBehaviour
{
    public Button startButton;

    public GameObject settingButton;
    public GameObject crossButton;

    public TMP_Text bestScoreText;
    public GameObject menuPanel;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (bestScoreText != null)
            bestScoreText.text = "Best Score: " + highScore.ToString();

        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpaceWaves");
    }

    public void onClickOfSetting()
    {
        settingButton.SetActive(false);
        crossButton.SetActive(true);
        menuPanel.SetActive(true);
    }

    public void onClickOfCross()
    {
        crossButton.SetActive(false);
        settingButton.SetActive(true);
        menuPanel.SetActive(false);
    }
}