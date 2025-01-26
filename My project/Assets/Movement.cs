using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float scale = 1f;
    [SerializeField] private float jumpForce = 10f;
    public Rigidbody2D body;
    private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;

    private float horizontalInput;
    private bool isGrounded;
    private float playerHalfHeight;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    private void Update()
    {
        // Apply horizontal movement
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip sprite based on movement direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(scale, scale, scale);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-scale, scale, scale);

        // Check if grounded and handle jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpJump();
        }

        // Update walking animation
        animator.SetBool("walk", horizontalInput != 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Get horizontal input
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    private bool GetIsGrounded()
    {
        // Cast ray to check if the player is on the ground
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, groundLayer);
        return isGrounded;
    }

    private void UpJump()
    {
        // Apply vertical force for jump
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }
}