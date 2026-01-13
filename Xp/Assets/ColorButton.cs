using UnityEngine;

public class ColorButton : MonoBehaviour
{
    private ColorMemoryTask task;

    void Start()
    {
        task = GetComponentInParent<ColorMemoryTask>();
    }

    void OnMouseDown()
    {
        task.PressColor(GetComponent<SpriteRenderer>().color);
    }
}
