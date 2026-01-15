using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneChanger : MonoBehaviour
{
    [SerializeField] private Animator animator; // The Animator with the animation
    [SerializeField] private string animationName; // Name of the animation state
    [SerializeField] private string sceneToLoad;   // Scene to load when animation ends

    private bool hasChangedScene = false;

    void Update()
    {
        if (hasChangedScene) return;

        // Check if the animation is playing
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f)
        {
            hasChangedScene = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
