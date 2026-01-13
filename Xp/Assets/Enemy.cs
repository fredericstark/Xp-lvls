using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float bounceForce = 10f; // how high the player bounces
    public GameObject deathEffect;  // optional particle effect

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get contact points to see if player hit the top of enemy
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Check if contact point is above enemy center
                if (contact.point.y > transform.position.y)
                {
                    // Player hit enemy on top → enemy dies
                    Die();

                    // Bounce player up
                    Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
                    }
                    return;
                }
            }

            // Player touched enemy from the side → player dies or takes damage
            PlayerRespawn player = collision.gameObject.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.Die(); // Or call a damage method
            }
        }
    }

    void Die()
    {
        // Optional death effect
        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
