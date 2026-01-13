using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float bounceForce = 10f; // how high the player bounces

    private int direction = -1; // -1 = left, 1 = right
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Flip when hitting walls
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            Flip();
        }

        // Player interaction
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Player jumped on top → destroy enemy and bounce
            if (collision.contacts[0].normal.y < -0.5f)
            {
                Destroy(gameObject);

                // Bounce the player
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                }
            }
            else
            {
                // Player hit from the side → call Die()
                PlayerRespawn playerRespawn = collision.gameObject.GetComponent<PlayerRespawn>();
                if (playerRespawn != null)
                {
                    playerRespawn.Die();
                }
            }
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(direction, 1, 1);
    }
}
