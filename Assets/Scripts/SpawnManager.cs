using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject[] obstacles;      
    public float minX = 8f;              
    public float maxX = 10f;            
    public float yPos = -1f;            
    public float spawnInterval = 2f;   

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (playerControllerScript != null && playerControllerScript.gameOver)
        {
            CancelInvoke(nameof(SpawnObstacle));
            return;
        }

        int index = Random.Range(0, obstacles.Length);
        GameObject obstacleToSpawn = obstacles[index];

        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, yPos);

        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}
