using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public PlayerController playerController;

    private float width;
   
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (playerController != null && !playerController.gameOver)
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
