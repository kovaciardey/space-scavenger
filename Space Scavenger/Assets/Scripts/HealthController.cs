using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // this Component will be updated to clamp the life to a maximum value and to also have a current life variable

    public float maxHealth = 100.0f; // player health value - will have a different value on the monster

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
    }

    public float GetMaxHealthValue()
    {
        return maxHealth;
    }

    // add health
    public void ApplyHealth(float amount)
    {
        maxHealth += amount;

        //Debug.Log(maxHealth);
    }

    // remove health
    public void ApplyDamage(float amount)
    {
        if (maxHealth > 0)
        {
            maxHealth -= amount;
        }

        if (maxHealth <= 0)
        {
            maxHealth = 0;
        }

        Debug.Log(maxHealth);
    }
}
