using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject healthPickUp;
    public GameObject ammoPickUp;

    public Vector3[] healthPickUpPositions;
    public Vector3[] ammoPickUpPositions;

    void Start()
    {
        SpawnPickUps();
    }

    private void SpawnPickUps()
    {
        foreach (Vector3 position in healthPickUpPositions)
        {
            Instantiate(healthPickUp, position, Quaternion.identity);
        }

        foreach (Vector3 position in ammoPickUpPositions)
        {
            Instantiate(ammoPickUp, position, Quaternion.identity);
        }
    }
}
