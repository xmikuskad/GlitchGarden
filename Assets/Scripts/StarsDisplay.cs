using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    TextMeshProUGUI starsText;
    float defaultDifficulty = 1f;

    void Start()
    {
        int difficulty = PlayerPrefsController.GetDifficulty(defaultDifficulty);
        switch(difficulty)
        {
            case 1:
                stars += 100;
                break;
            case 2:
                stars += 50;
                break;
            default:
                break;
        }
        starsText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }

    public bool HaveEnoughStart(int amount)
    {
        if (amount <= stars)
            return true;
        else
            return false;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
