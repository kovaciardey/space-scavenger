using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Checks if the reactor has been claimed yet, and does not allow to claim it again if yes 
 */

public class ReactorController : MonoBehaviour
{
    public bool HasBeenClaimed { get; set; }
    public int ScrapAmount { get; set; }

    private void Start()
    {
        HasBeenClaimed = false;
        ScrapAmount = GetComponent<ScrapSpawner>().GetScrapToDrop();
    }
}
