using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public int maxAmmo = 100;

    public void SubtractAmmo() // only shoot 1 bullet at a time
    {
        maxAmmo -= 1;

        if (maxAmmo <= 0)
        {
            maxAmmo = 0;
        }

        Debug.Log(maxAmmo);
    }

    public void AddAmmo(int amount) // increase the ammo count
    {
        maxAmmo += amount;

        Debug.Log(maxAmmo);
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }
}
