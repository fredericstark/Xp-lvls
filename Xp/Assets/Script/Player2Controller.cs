using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 10f; // higher jump

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Controls")]
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.UpArrow;

    [Header("Jump Settings")]
    public int maxJumps = 2; // double jump

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded;
    private int jumpsLeft;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded) jumpsLeft = maxJumps;

        // Horizontal movement
        float move = 0f;
        if (Input.GetKey(leftKey)) move = -1f;
        if (Input.GetKey(rightKey)) move = 1f;

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Flip sprite
        if (move < 0) sprite.flipX = true;
        else if (move > 0) sprite.flipX = false;

        // Jump (double)
        if (Input.GetKeyDown(jumpKey) && jumpsLeft > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsLeft--;
        }
    }
}