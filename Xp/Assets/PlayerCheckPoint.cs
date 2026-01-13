using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {

        respawnPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Checkpoint reached: " + respawnPoint);
    }

    public void Die()
    {

        transform.position = respawnPoint;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

