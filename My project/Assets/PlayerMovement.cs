using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool grounded;

    float horizontalMovement;

    private float playerHalfHeight;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement update.
        player.linearVelocity = new Vector2(horizontalMovement * moveSpeed, player.linearVelocity.y);

        //RaycastHit2D
        Debug.DrawRay(transform.position, Vector2.down * (playerHalfHeight + 0.1f), Color.red);

        if(Input.GetKeyDown(KeyCode.Space) && GetIsGrounded()) {
           Jump();
        }
    }

    private bool GetIsGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"));

    }


    public void Move(InputAction.CallbackContext context) 
    {
        // Read horizontal movement (X-axis)
        horizontalMovement = context.ReadValue<Vector2>().x;

    }

    private void Jump()
    {
        player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
    }
}
