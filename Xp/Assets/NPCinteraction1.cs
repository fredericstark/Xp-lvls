using UnityEngine;

public class NPCinteraction : MonoBehaviour
{
    [SerializeField] private GameObject prologueUI;
    [SerializeField] private GameObject dialogueUI;

    private bool playerInRange = false;

    void Start()
    {
        prologueUI.SetActive(false);
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);
            prologueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            prologueUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            prologueUI.SetActive(false);
            dialogueUI.SetActive(false);
        }
    }
}
