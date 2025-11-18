using UnityEngine;
using UnityEngine.UI;

public class AudioToggleUI : MonoBehaviour
{
    public Button musicOnBtn;
    public Button musicOffBtn;
    public Button soundOnBtn;
    public Button soundOffBtn;

    private void Start()
    {
        musicOnBtn.onClick.AddListener(() => SetMusic(false));
        musicOffBtn.onClick.AddListener(() => SetMusic(true));

        soundOnBtn.onClick.AddListener(() => SetSound(false));
        soundOffBtn.onClick.AddListener(() => SetSound(true));

        UpdateMusicUI();
        UpdateSoundUI();
    }

    private void SetMusic(bool status)
    {
        AudioManager.Instance.SetMusic(status);
        UpdateMusicUI();
    }

    private void SetSound(bool status)
    {
        AudioManager.Instance.SetSound(status);
        UpdateSoundUI();
    }

    private void UpdateMusicUI()
    {
        bool isOn = AudioManager.Instance.isMusicOn;

        musicOnBtn.gameObject.SetActive(isOn);  
        musicOffBtn.gameObject.SetActive(!isOn);  
    }

    private void UpdateSoundUI()
    {
        bool isOn = AudioManager.Instance.isSoundOn;

        soundOnBtn.gameObject.SetActive(isOn);   
        soundOffBtn.gameObject.SetActive(!isOn);  
    }
}

