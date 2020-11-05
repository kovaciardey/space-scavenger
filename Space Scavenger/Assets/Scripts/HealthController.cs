using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100.0f;

    public float GetMaxHealthValue()
    {
        return maxHealth;
    }

    public void ApplyHealth(float amount)
    {
        maxHealth += amount;

        Debug.Log(maxHealth);
    }

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
