using UnityEngine;

public class NPCinteraction : MonoBehaviour
{
    public GameObject interactText;   // "Press E to talk"
    public GameObject dialogueText;   // "Hello there!"

    private bool playerInRange = false;

    void Start()
    {
        interactText.SetActive(false);
        dialogueText.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueText.SetActive(true);
            interactText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.SetActive(false);
            dialogueText.SetActive(false);
        }
    }
}
