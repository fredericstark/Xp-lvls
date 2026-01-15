using UnityEngine;

public class Lava : MonoBehaviour
{
    [Header("Movement Settings")]
    public float riseSpeed = 2f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    [Header("Player Kill")]
    public bool isTrigger = true;

    private bool movingUp = true;

    void Update()
    {
        Vector3 pos = transform.position;

        if (movingUp)
        {
            pos.y += riseSpeed * Time.deltaTime;
            if (pos.y >= maxHeight)
                movingUp = false;
        }
        else
        {
            pos.y -= riseSpeed * Time.deltaTime;
            if (pos.y <= minHeight)
                movingUp = true;
        }

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTrigger && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>()?.Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTrigger && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerRespawn>()?.Die();
        }
    }
}
