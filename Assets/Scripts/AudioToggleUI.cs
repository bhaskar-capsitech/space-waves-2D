using UnityEngine;
using UnityEngine.UI;

public class AudioToggleUI : MonoBehaviour
{
    public Button audioOnButton;
    public Button audioOffButton;

    void Start()
    {
        audioOnButton.onClick.AddListener(() => SetAudio(true));
        audioOffButton.onClick.AddListener(() => SetAudio(false));

        UpdateButtons();
    }

    void SetAudio(bool on)
    {
        AudioManager.Instance.SetMute(!on);
        UpdateButtons();
    }

    void UpdateButtons()
    {

        bool isMuted = AudioManager.Instance.IsMuted();
        audioOnButton.gameObject.SetActive(isMuted);
        audioOffButton.gameObject.SetActive(!isMuted);

    }
}
