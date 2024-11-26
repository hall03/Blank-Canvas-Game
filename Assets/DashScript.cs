using UnityEngine;

public class DashScript: MonoBehaviour
{
    // Public settings for easy tweaking
    [Header("Dash Settings")]
    public float dashSpeed = 20f;          // Speed of the dash
    public float dashDuration = 0.2f;     // Duration of the dash in seconds
    public float dashCooldown = 1f;       // Cooldown time between dashes

    [Header("Player Movement")]
    public Rigidbody2D playerRigidbody;   // Reference to the player's Rigidbody2D component
    public float normalSpeed = 5f;        // Speed when not dashing
    public float normalGravity = 1f;      // Player gravity

    private bool isDashing = false;       // Whether the player is currently dashing
    private float dashTime;               // Timer for dash
    private float dashCooldownTimer;      // Timer for dash cooldown
    private float horizontalInput;        // Horizontal input from the player

    void Update()
    {
        // Get horizontal movement input
        horizontalInput = Input.GetAxis("Horizontal");

        // Dash logic (triggered with the Q key)
        if (Input.GetKeyDown(KeyCode.Q) && dashCooldownTimer <= 0 && gameObject.GetComponent<PlayerMovement>().powerUp >= 1)
        {
           Dash();
        }

        // Reduce cooldown timer
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Movement logic
        if (isDashing)
        {
            // Dash movement (horizontal only)
            playerRigidbody.linearVelocity = new Vector2(Mathf.Sign(horizontalInput) * dashSpeed, 0f);
            playerRigidbody.gravityScale = 0f;
        }
        else
        {
            // Normal movement (horizontal only)
            playerRigidbody.linearVelocity = new Vector2(horizontalInput * normalSpeed, playerRigidbody.linearVelocity.y);
        }
    }

    void Dash()
    {
        // Only dash if there's horizontal input
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            isDashing = true;
            dashTime = dashDuration;
            dashCooldownTimer = dashCooldown;

            // Stop the dash after the duration
            Invoke(nameof(EndDash), dashDuration);
        }
    }

    void EndDash()
    {
        isDashing = false;
        playerRigidbody.gravityScale = normalGravity;
    }
}