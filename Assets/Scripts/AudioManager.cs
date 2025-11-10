using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private bool isMuted = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMuteState();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        ApplyMuteState();
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void SetMute(bool mute)
    {
        isMuted = mute;
        ApplyMuteState();
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    private void ApplyMuteState()
    {
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}

