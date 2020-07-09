using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;
    [SerializeField] int starGenerate = 10;

    StarsDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarsDisplay>();
    }

    public void AddStars()
    {
        starDisplay.AddStars(starGenerate);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
