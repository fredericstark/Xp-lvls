using UnityEngine;

public class EXPOnTouch : MonoBehaviour
{
    [Header("EXP Settings")]
    public int expAmount = 10;

    private bool collected = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !collected)
        {
            collected = true;


            PlayerEXP playerExp = collision.gameObject.GetComponent<PlayerEXP>();
            if (playerExp != null)
            {
                playerExp.GainEXP(expAmount);
            }


            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collected)
        {
            collected = true;

            PlayerEXP playerExp = collision.GetComponent<PlayerEXP>();
            if (playerExp != null)
            {
                playerExp.GainEXP(expAmount);
            }

            Destroy(gameObject);
        }
    }
}
