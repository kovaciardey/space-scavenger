using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS NOT USED

// small script to visualize the damage to the player
public class ChangePlayerColour : MonoBehaviour
{
    private float playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<HealthController>().GetCurrentHealth();

        Debug.Log(Mathf.InverseLerp(0.0f, 255.0f, playerHealth));
    }

    private void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {

    }
}
