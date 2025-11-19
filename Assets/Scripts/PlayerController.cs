using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 16f;
    public float gravityModifier = 2.25f;
    public float rotationDuration = 0.15f;

    public bool gameOver = false;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private Rigidbody2D rb;

    private int jumpCount = 0;
    private int maxJumps = 2;
    private bool isGrounded = true;

    private bool restartScheduled = false;
    private bool isRotating = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -9.81f * gravityModifier);
    }

    void Update()
    {
        if (!gameOver)
        {
            bool jumpPressed = false;

            if (Input.GetKeyDown(KeyCode.Space))
                jumpPressed = true;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject() &&
                    !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    jumpPressed = true;
                }
            }

            if (jumpPressed && jumpCount < maxJumps)
            {
                Jump();
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayJump();
            }
        }
        else if (!restartScheduled)
        {
            restartScheduled = true;
            Invoke(nameof(RestartGame), 1.5f);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (dirtParticle != null)
            dirtParticle.Stop();

        isGrounded = false;

        jumpCount++;       

        if (!isRotating)
            StartCoroutine(Rotate90Degrees());
    }

    IEnumerator Rotate90Degrees()
    {
        isRotating = true;

        float elapsed = 0f;
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + 270f;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            float z = Mathf.LerpAngle(startRotation, endRotation, elapsed / rotationDuration);
            transform.rotation = Quaternion.Euler(0, 0, z);
            yield return null;
        }

        isRotating = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (dirtParticle != null)
                dirtParticle.Play();

            isGrounded = true;

            jumpCount = 0;       

            transform.rotation = Quaternion.identity;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle");
            if (explosionParticle != null)
                explosionParticle.Play();

            if (dirtParticle != null)
                dirtParticle.Stop();

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayCrash();

            gameOver = true;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
