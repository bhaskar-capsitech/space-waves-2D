using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (ScoreManager.instance != null)
                ScoreManager.instance.IncreaseScore(1);
        }
    }
}
