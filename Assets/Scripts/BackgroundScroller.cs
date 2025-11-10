using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;

    private float width;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (playerControllerScript != null && !playerControllerScript.gameOver)
        {

            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            if (transform.position.x <= -width)
            {
                Vector3 newPos = transform.position;
                newPos.x += width * 2; 
                transform.position = newPos;
            }
        }
    }
}
