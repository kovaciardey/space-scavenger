using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapSpawner : MonoBehaviour
{
    private int scrapToDrop;

    private void Start()
    {
        scrapToDrop = Random.Range(30, 60);
    }

    public int GetScrapToDrop()
    {
        return scrapToDrop;
    }
}
