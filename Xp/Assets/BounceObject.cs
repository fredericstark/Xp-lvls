using UnityEngine;

public class BounceObject : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceForce = 10f; // how high the player bounces

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the collision was from above
            if (collision.contacts[0].normal.y < -0.5f)
            {
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    // Bounce the player up
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                }
            }
        }
    }
}
