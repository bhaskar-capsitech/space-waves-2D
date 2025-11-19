using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgMusicSource;
    public AudioSource effectsSource;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public AudioClip buttonSound;

    public bool isMusicOn = true;
    public bool isSoundOn = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (isMusicOn)
        {
            SetMusic(true);
        }
    }

    public void SetMusic(bool status)
    {
        isMusicOn = status;

        if (bgMusicSource == null) return;

        if (status)
        {
            if (!bgMusicSource.isPlaying)
                bgMusicSource.Play();
        }
        else
        {
            bgMusicSource.Stop();
        }
    }

    public void SetSound(bool status)
    {
        isSoundOn = status;

        if (effectsSource != null)
            effectsSource.volume = status ? 1f : 0f;
    }

    public void PlayCrash()
    {
        if (isSoundOn && effectsSource != null && crashSound != null)
            effectsSource.PlayOneShot(crashSound, 1.0f);
    }

    public void PlayJump()
    {
        if (isSoundOn && effectsSource != null && jumpSound != null)
            effectsSource.PlayOneShot(jumpSound, 1.0f);
    }

    public void PlayButtonSound()
    {
        if (isSoundOn && effectsSource != null && buttonSound != null)
        {
            effectsSource.PlayOneShot(buttonSound, 1.0f);
        }
    }
}