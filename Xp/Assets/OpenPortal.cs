using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    [Header("Portal Settings")]
    public GameObject portal;
    private bool playerInRange = false;
    private bool portalActivated = false;

    void Update()
    {

        if (playerInRange && !portalActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivatePortal();
        }
    }

    void ActivatePortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);
            portalActivated = true;
            Debug.Log("Portal activated!");
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
