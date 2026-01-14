using UnityEngine;

public class KillPlayer : MonoBehaviour

{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player2;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector2(-42, -7);
            Player2.transform.position = new Vector2(-42, -7)
; PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Die();
            }

        }
    }

}

