using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    DefenderSpawner defenderSpawner;

    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogError("MISSING TEXT FIELD ON "+name);
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }

}
