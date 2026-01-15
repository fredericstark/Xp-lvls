using UnityEngine;

public class RemoveGround : MonoBehaviour
{
    [Header("Ground to Remove")]
    public GameObject groundPiece;

    private bool playerInRange = false;
    private bool leverPulled = false;

    void Update()
    {
        if (playerInRange && !leverPulled && Input.GetKeyDown(KeyCode.E))
        {
            PullLever();
        }
    }

    void PullLever()
    {
        if (groundPiece != null)
        {
            Destroy(groundPiece);
            leverPulled = true;
            Debug.Log("Lever pulled! Ground removed.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;
    }
}
