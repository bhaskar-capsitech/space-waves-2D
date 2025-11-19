using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomePageManager : MonoBehaviour
{
    public Button startButton;

    public GameObject settingButton;
    public GameObject crossButton;

    public TMP_Text highScoreText;
    public GameObject menuPanel;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;

        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpaceWaves");

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayButtonSound();
    }

    public void onClickOfSetting()
    {
        settingButton.SetActive(false);
        crossButton.SetActive(true);
        menuPanel.SetActive(true);

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayButtonSound();
    }

    public void onClickOfCross()
    {
        crossButton.SetActive(false);
        settingButton.SetActive(true);
        menuPanel.SetActive(false);

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayButtonSound();
    }
}