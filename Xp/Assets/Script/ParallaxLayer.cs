using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxStrength = 0.5f;

    private Transform cameraTransform;
    private Vector3 startPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPosition = transform.position;
    }

    void LateUpdate()
    {
        Vector3 cameraPos = cameraTransform.position;

        transform.position = new Vector3(
            startPosition.x + cameraPos.x * parallaxStrength,
            startPosition.y + cameraPos.y * parallaxStrength,
            startPosition.z
        );
    }
}