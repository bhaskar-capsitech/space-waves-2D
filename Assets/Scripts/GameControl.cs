using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject pausePanel;

    private bool musicBeforePause;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        pausePanel.SetActive(true);

        if (AudioManager.Instance != null)
        {
            musicBeforePause = AudioManager.Instance.isMusicOn;
            AudioManager.Instance.SetMusic(false);
            
            AudioManager.Instance.PlayButtonSound(); 
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);

        if (AudioManager.Instance != null)
        {
            if (musicBeforePause)
            {
                AudioManager.Instance.SetMusic(true);
            }
            AudioManager.Instance.PlayButtonSound();
        }
    }

    public void Home()
    {
        Time.timeScale = 1f;
        if (AudioManager.Instance != null)
        {
            if (musicBeforePause)
            {
                AudioManager.Instance.SetMusic(true);
            }
            AudioManager.Instance.PlayButtonSound();
        }
        SceneManager.LoadScene("HomePage");
    }

    public void QuitGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonSound();
        }
        Application.Quit();
    }
}
