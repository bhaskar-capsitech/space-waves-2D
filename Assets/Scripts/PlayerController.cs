using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public bool gameOver = false;

    [Header("Particles")]
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    [Header("Jump Settings")]
    public float jumpForce = 16f;
    public float gravityModifier = 2.25f;
    public float rotationDuration = 0.15f;

    private bool restartScheduled = false;
    private bool isRotating = false;

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -9.81f * gravityModifier);
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameOver)
        {
            if ((Input.GetKeyDown(KeyCode.Space) ||
                 (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
                 && isGrounded)
            {
                Jump();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
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


            transform.rotation = Quaternion.identity;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle");
            if (explosionParticle != null)
                explosionParticle.Play();

            if (dirtParticle != null)
            {
               dirtParticle.Stop();
            }
            
            playerAudio.PlayOneShot(crashSound, 1.0f);

            gameOver = true;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


