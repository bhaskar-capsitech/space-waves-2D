using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public float minX = 2f;
    public float maxX = 8f;
    public float yPos = -4.2f;

    public float initialSpawnInterval = 1.7f;
    public float minSpawnInterval = 1.2f;  
    public float difficultyIncreaseRate = 0.01f; 

    public float firstSpawnDelay = 0.3f; 

    private float currentSpawnInterval;
    private float timeSinceStart;
    private float nextSpawnTime;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        currentSpawnInterval = initialSpawnInterval;

        nextSpawnTime = Time.time + firstSpawnDelay;
    }

    void Update()
    {
        if (playerControllerScript != null && playerControllerScript.gameOver)
            return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + currentSpawnInterval;
        }

        timeSinceStart += Time.deltaTime;
        currentSpawnInterval = Mathf.Max(minSpawnInterval, initialSpawnInterval - (timeSinceStart * difficultyIncreaseRate));
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacleToSpawn = obstacles[index];

        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, yPos);

        Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);
    }
}
