using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapController : MonoBehaviour
{
    private int scrapValue;

    private void Start()
    {
        scrapValue = 0;
    }
    
    public void AddScrap(int amount)
    {
        scrapValue += amount;
    }

    public int GetScrapAmount()
    {
        return scrapValue;
    }
}
