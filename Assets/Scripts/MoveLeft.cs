using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -16f;
    private PlayerController playerControllerScript;
    private bool hasScored = false;

    public float speed = 5f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Move obstacles only while game is active
        if (playerControllerScript != null && !playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Destroy obstacle when it goes off screen
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        // Give score when obstacle passes the player
        if (!hasScored &&
            transform.position.x < playerControllerScript.transform.position.x &&
            gameObject.CompareTag("Obstacle"))
        {
            hasScored = true;
            if (ScoreManager.instance != null)
                ScoreManager.instance.IncreaseScore(1);
        }
    }
}
