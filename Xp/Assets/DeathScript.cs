using UnityEngine;


public class RespawnTile2D : MonoBehaviour
{
    private Vector2 respawnBasePosition = new Vector2(-42f, -7f);
    private float playerOffset = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn(other, respawnBasePosition + Vector2.left * playerOffset);
        }
        else if (other.CompareTag("Player2"))
        {
            Respawn(other, respawnBasePosition + Vector2.right * playerOffset);
        }
    }

    private void Respawn(Collider2D player, Vector2 position)
    {
        player.transform.position = position;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
