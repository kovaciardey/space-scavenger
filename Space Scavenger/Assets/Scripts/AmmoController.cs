using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public int clipSize = 15;
    public int startingAmmo = 100;

    public float reloadTime = 3f;

    public int CurrentClipAmmo { get; set; }
    public int CurrentAmmo { get; set; }
    public float CurrentReloadTime { get; set; }

    private bool isReloading;

    void Start()
    {
        isReloading = false;
        CurrentClipAmmo = clipSize;
        CurrentAmmo = startingAmmo;    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !isReloading)
        {
            StartCoroutine(ReloadRoutine());
        }    
    }

    public void SubtractAmmo() // only shoot 1 bullet at a time
    {
        CurrentClipAmmo -= 1;

        if (CurrentClipAmmo <= 0)
        {
            CurrentClipAmmo = 0;
        }

        //Debug.Log(maxAmmo);
    }

    public void AddAmmo(int amount) // increase the ammo count
    {
        startingAmmo += amount;

        //Debug.Log(maxAmmo);
    }

    public int GetMaxAmmo()
    {
        return startingAmmo;
    }

    IEnumerator ReloadRoutine()
    {
        if (isReloading)
        {
            yield break;
        }

        CurrentReloadTime = 0;

        while (CurrentReloadTime < reloadTime)
        {
            CurrentReloadTime += Time.deltaTime;

            yield return null;
        }

        CurrentReloadTime = reloadTime;

        isReloading = false;
    }
}
