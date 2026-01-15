using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Power-Up Settings")]
    public float jumpMultiplier = 2f;
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Player1Controller player = collision.GetComponent<Player1Controller>();
            if (player != null)
            {
                StartCoroutine(ApplyPowerUp(player));
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator ApplyPowerUp(Player1Controller player)
    {
        player.jumpForce *= jumpMultiplier;
        yield return new WaitForSeconds(duration);
        player.jumpForce /= jumpMultiplier;
    }
}
