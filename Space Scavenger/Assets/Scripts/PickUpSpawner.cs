using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject pickUp;

    public Vector3[] pickUpPositions;

    void Start()
    {
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        foreach (Vector3 position in pickUpPositions)
        {
            Instantiate(pickUp, position, Quaternion.identity);
        }
    }
}
