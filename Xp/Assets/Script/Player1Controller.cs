using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 10f; // small jump

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [SerializeField] private Animator _animator;

    [Header("Controls")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float move = 0f;
        if (Input.GetKey(leftKey))
        {
            move = -1f;
        }
            
        if (Input.GetKey(rightKey))
        {
            move = 1f;
        }


        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Flip sprite
        if (move < 0) sprite.flipX = true;
        else if (move > 0) sprite.flipX = false;

        // Jump (single)
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}