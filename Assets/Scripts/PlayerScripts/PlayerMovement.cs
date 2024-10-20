using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 movement;      // Stores last direction of movement
    private Vector2 lastDirection;
    private bool isFacingRight = true;

    // Set limits for the rotation angles 
    public float minRotationAngle = -120f;
    public float maxRotationAngle = 120f;

    private AudioManager audioManager;
    private float lastSwimmingSoundTime = 0f;
    public float swimmingSoundInterval = 100f;


    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Update()
    {
        // player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        if (movement.magnitude > 0)
        {
            animator.SetBool("IsSwimming", true);
            lastDirection = movement;

            // Play swimming sound
            if (Time.time - lastSwimmingSoundTime > swimmingSoundInterval)
            {
                if (audioManager != null && audioManager.Swim != null)
                {
                    audioManager.PlaySFX(audioManager.Swim);
                    lastSwimmingSoundTime = Time.time;
                }
            }
        }
        else
        {
            animator.SetBool("IsSwimming", false);
        }

        FlipCharacter();
        RotatePlayer();
    }

    void FixedUpdate()
    {
        // Move player 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FlipCharacter()
    {
        // Only flip horizontally if the player is moving purely left or right
        if (movement.x < 0 && isFacingRight)
        {
            // Flip to face left
            Flip();
        }
        else if (movement.x > 0 && !isFacingRight)
        {
            // Flip to face right
            Flip();
        }
    }

    void Flip()
    {
        // all the logicFlip the character 
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void RotatePlayer()
    {
        //all the logic for my player rotations
        if (movement.magnitude > 0)
        {
            Vector2 directionToRotate = movement;
            if (Mathf.Abs(movement.x) < 0.1f)
            {
                directionToRotate = new Vector2(0, movement.y);
            }
            float targetAngle = Mathf.Atan2(directionToRotate.y, directionToRotate.x) * Mathf.Rad2Deg - 90;
            targetAngle = Mathf.Clamp(targetAngle, minRotationAngle, maxRotationAngle);
            float currentAngle = transform.rotation.eulerAngles.z;
            float smoothedAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime / 360f);
            transform.rotation = Quaternion.Euler(0, 0, smoothedAngle);
        }
    }

}
