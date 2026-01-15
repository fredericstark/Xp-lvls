using UnityEngine;

public class DeathObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
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
    }
}

