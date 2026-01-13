using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    public GameObject task1;
    public bool taskActive = false;
    public bool taskCompleted = false;

    private void Awake()
    {
        // If another TaskManager exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        print("inne i instance");

        // Optional: keep this object between scenes
        // DontDestroyOnLoad(gameObject);
    }

    public void StartTask()
    {
        taskActive = true;
        taskCompleted = false;
        task1.SetActive(true);
        Debug.Log("Task started");
    }

    public void CompleteTask()
    {
        taskActive = false;
        taskCompleted = true;
        Debug.Log("Task completed – Memory unlocked");
    }
}
