using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSceneDebug : MonoBehaviour
{
    public ShipSceneController shipController;

    public int scrapAmount = 500;
    public int expAmount = 50;

    public void AddScrap()
    {
        shipController.AddScrap(scrapAmount);
    }

    public void AddExperience()
    {
        shipController.AddExperience(expAmount);
    }
}
