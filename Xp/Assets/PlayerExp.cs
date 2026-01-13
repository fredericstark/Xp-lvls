using UnityEngine;
using UnityEngine.UI;

public class PlayerEXP : MonoBehaviour
{
    [Header("EXP Settings")]
    public int currentEXP = 0;
    public int expToLevelUp = 100;

    [Header("UI")]
    public Slider expBar;

    void Start()
    {
        if (expBar != null)
        {
            expBar.maxValue = expToLevelUp;
            expBar.value = currentEXP;
        }
    }


    public void GainEXP(int amount)
    {
        currentEXP += amount;


        if (currentEXP >= expToLevelUp)
        {
            currentEXP -= expToLevelUp;
            LevelUp();
        }

        UpdateEXPBar();
    }

    void UpdateEXPBar()
    {
        if (expBar != null)
            expBar.value = currentEXP;
    }

    void LevelUp()
    {
        Debug.Log("Level Up!");

        expToLevelUp = Mathf.RoundToInt(expToLevelUp * 1.2f);
        if (expBar != null)
            expBar.maxValue = expToLevelUp;
    }
}
