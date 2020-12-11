using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public int maxShields = 3;

    public float shieldRechargeDelay = 5f;

    private int currentShields;
    private bool isRegenerating = false;

    private void Start()
    {
        ResetShields();
    }

    public void SetMaxShields(int amount)
    {
        maxShields = amount;
    }

    public int GetMaxShields()
    {
        return maxShields;
    }

    public int GetCurrentShields()
    {
        return currentShields;
    }

    public void IncreaseShields()
    {
        if ((currentShields + 1) >= maxShields)
        {
            currentShields = maxShields;
        } 
        else
        {
            currentShields += 1;
        }
    }

    public void ApplyShieldDamage()
    {
        if (currentShields - 1 <= 0)
        {
            currentShields = 0;
        }
        else
        {
            currentShields -= 1;
        }

        if (!isRegenerating)
        {
            StartCoroutine("ShieldRecharge");
        }
    }

    public void ResetShields()
    {
        currentShields = maxShields;
    }

    IEnumerator ShieldRecharge()
    {
        isRegenerating = true;

        while (currentShields < maxShields)
        {
            yield return new WaitForSeconds(shieldRechargeDelay);

            IncreaseShields();
        }

        isRegenerating = false;
    }
}
