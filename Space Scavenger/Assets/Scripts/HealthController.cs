using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // this Component will be updated to clamp the life to a maximum value and to also have a current life variable

    public float maxHealth = 100.0f;  // player health value - will have a different value on the monster

    private float currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // add health
    public void ApplyHealth(float amount)
    {
        if ((currentHealth + amount) >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        //Debug.Log(maxHealth);
    }

    // remove health
    public void ApplyDamage(float amount)
    {
        if ((currentHealth - amount) <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= amount;
        }

        //Debug.Log(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
