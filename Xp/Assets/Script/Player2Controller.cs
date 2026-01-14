using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public LayerMask groundLayer;

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.UpArrow;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float moveInput;
    private int jumpsLeft;
    private bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(leftKey)) moveInput = -1f;
        if (Input.GetKey(rightKey)) moveInput = 1f;

        if (Input.GetKeyDown(jumpKey) && jumpsLeft > 0)
        {
            jumpPressed = true;
            jumpsLeft--;
        }

        if (moveInput < 0) sprite.flipX = true;
        else if (moveInput > 0) sprite.flipX = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            jumpsLeft = maxJumps;
    }
}
