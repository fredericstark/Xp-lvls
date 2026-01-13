using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxStrength = 0.5f;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousCameraPosition;

        transform.position += new Vector3(
            delta.x * parallaxStrength,
            delta.y * parallaxStrength,
            0f
        );

        previousCameraPosition = cameraTransform.position;
    }
}