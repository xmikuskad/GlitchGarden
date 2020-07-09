using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    float playerHealth;
    [SerializeField] float basePlayerHealth = 5;
    TextMeshProUGUI healthtext;
    float defaultDifficulty = 1f;

    void Start()
    {
        playerHealth = basePlayerHealth - PlayerPrefsController.GetDifficulty(defaultDifficulty);
        healthtext = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    private void UpdateText()
    {
        healthtext.text = "Lives: "+ playerHealth.ToString();
    }
    
    public void TakeLife()
    {
        playerHealth -= 1;
        if(playerHealth<=0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        UpdateText();
    }

}
