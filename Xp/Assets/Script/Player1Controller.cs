using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded;
    private float moveInput;
    private bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // INPUT ONLY
        moveInput = 0f;
        if (Input.GetKey(leftKey)) moveInput = -1f;
        if (Input.GetKey(rightKey)) moveInput = 1f;

        if (Input.GetKeyDown(jumpKey) && isGrounded)
            jumpPressed = true;

        if (moveInput < 0) sprite.flipX = true;
        else if (moveInput > 0) sprite.flipX = false;
    }

    void FixedUpdate()
    {
        // PHYSICS ONLY
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            isGrounded = false;
    }
}
