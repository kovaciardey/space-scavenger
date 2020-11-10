using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawn a pickUp at random with a chance of 50%
 */

public class SpawnPickUpOnKill : MonoBehaviour
{
    public GameObject[] possiblePickUps;

    public float pickUpSpawnChance = 0.5f;

    public void SpawnPickUp()
    {
        float randomValue = Random.value;

        if (randomValue <= pickUpSpawnChance)
        {
            int randomPickUp = Random.Range(0, possiblePickUps.Length);

            Instantiate(possiblePickUps[randomPickUp], gameObject.transform.position, Quaternion.identity);
        }
    }
}
