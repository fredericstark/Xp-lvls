using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        // Set initial respawn point to starting position
        respawnPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Checkpoint reached: " + respawnPoint);
    }

    public void Die()
    {
        // Respawn at last checkpoint
        transform.position = respawnPoint;
        // Optional: reset velocity if using Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

