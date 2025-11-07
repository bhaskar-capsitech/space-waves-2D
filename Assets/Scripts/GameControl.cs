using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pauseButton;   
    public GameObject resumeButton;  
    public GameObject quitButton;    

    void Start()
    {
        resumeButton.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("HomePage");
    }
}
