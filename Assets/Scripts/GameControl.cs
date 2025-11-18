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
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);

        if (AudioManager.Instance != null && musicBeforePause)
        {
            AudioManager.Instance.SetMusic(true); 
        }
    }

    public void Home()
    {
        Time.timeScale = 1f;
        if (AudioManager.Instance != null && musicBeforePause)
        {
            AudioManager.Instance.SetMusic(true);
        }
        SceneManager.LoadScene("HomePage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
