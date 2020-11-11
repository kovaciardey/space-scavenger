using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Sets the amount of scrap the game object should award
 * 
 * if randomized it sets a random value between the set min and max values 
 * 
 * else it takes the value in the scrapAmount variable
 */

public class ScrapSpawner : MonoBehaviour
{
    public int scrapAmount = 100;

    public bool randomize = true;

    public int minValue = 30;
    public int maxValue = 60;

    private int scrapToDrop;

    private void Start()
    {
        if (randomize)
        {
            scrapToDrop = Random.Range(minValue, maxValue);
        }
        else
        {
            scrapToDrop = scrapAmount;
        }
        
    }

    public int GetScrapToDrop()
    {
        return scrapToDrop;
    }
}
