using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpController : MonoBehaviour
{
    private int ammoAdded = 15; // ammo added to the player

    public int GetAmmoAdded()
    {
        return ammoAdded;
    }
}
