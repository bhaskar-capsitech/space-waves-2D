using UnityEngine;

public class GamePerformanceManager : MonoBehaviour
{
    [Header("Frame Rate Settings")]
    [Tooltip("Set your desired target frame rate (commonly 60 or 120 for mobile).")]
    public int targetFrameRate = 120;

    void Awake()
    {
        // Disable VSync for mobile devices (it can conflict with targetFrameRate)
        QualitySettings.vSyncCount = 0;

        // Set your desired frame rate globally
        Application.targetFrameRate = targetFrameRate;
    }
}
