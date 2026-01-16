using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Camera>().orthographicSize = 27;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
