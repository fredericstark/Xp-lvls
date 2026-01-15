using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private string sceneToLoad;

    private void Start()
    {
        Invoke(nameof(ChangeScene), delay);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
