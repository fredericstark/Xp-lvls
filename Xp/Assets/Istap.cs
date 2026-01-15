using UnityEngine;

public class Istap : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRespawn respawn =
                collision.gameObject.GetComponent<PlayerRespawn>();

            if (respawn != null)
            {
                respawn.Die();
            }
        }


        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetObject();
        }
    }

    void ResetObject()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
    }
}
