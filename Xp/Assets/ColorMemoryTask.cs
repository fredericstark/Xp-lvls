using UnityEngine;

public class ColorMemoryTask : MonoBehaviour
{
    public SpriteRenderer[] buttons;
    public Color[] sequence;

    private int currentIndex = 0;
    private bool playerTurn = false;

    void OnEnable()
    {
        GenerateSequence();
        ShowSequence();
    }

    void GenerateSequence()
    {
        sequence = new Color[3];

        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = buttons[Random.Range(0, buttons.Length)].color;
        }
    }

    void ShowSequence()
    {
        StartCoroutine(PlaySequence());
    }

    System.Collections.IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(1f);
        foreach (Color c in sequence)
        {
            Highlight(c);
            yield return new WaitForSeconds(0.7f);
        }
        playerTurn = true;
        currentIndex = 0;
    }

    void Highlight(Color color)
    {
        foreach (var b in buttons)
        {
            if (b.color == color)
            {
                b.color = Color.white;
                Invoke(nameof(ResetColors), 0.3f);
            }
        }
    }

    void ResetColors()
    {
        foreach (var b in buttons)
        {
            b.color *= 0.7f;
        }
    }

    public void PressColor(Color pressedColor)
    {
        if (!playerTurn) return;

        if (pressedColor == sequence[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= sequence.Length)
            {
                TaskManager.Instance.CompleteTask();
                gameObject.SetActive(false);
            }
        }
        else
        {
            currentIndex = 0;
            playerTurn = false;
            ShowSequence();
        }
    }
}
