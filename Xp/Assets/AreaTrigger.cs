using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public GameObject taskObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TaskManager.Instance.StartTask();
            taskObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
