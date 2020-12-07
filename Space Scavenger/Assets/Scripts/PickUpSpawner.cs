using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject healthPickUp;
    public GameObject ammoPickUp;

    public Vector3[] healthPickUpPositions;
    public Vector3[] ammoPickUpPositions;

    private List<GameObject> healthPickUps;
    private List<GameObject> ammoPickUps;

    void Start()
    {
        healthPickUps = new List<GameObject>();
        ammoPickUps = new List<GameObject>();

        SpawnPickUps();
    }

    public void SpawnPickUps()
    {
        ClearPickUps();

        healthPickUps.Clear();
        ammoPickUps.Clear();

        // spawn health and ammo pickups respectively at hard-coded locations
        foreach (Vector3 position in healthPickUpPositions)
        {
            healthPickUps.Add(Instantiate(healthPickUp, position, Quaternion.identity));
        }

        foreach (Vector3 position in ammoPickUpPositions)
        {
            ammoPickUps.Add(Instantiate(ammoPickUp, position, Quaternion.identity));
        }
    }

    // Destroys any existing pickups the spawner created so as to not get any duplicate game objects
    private void ClearPickUps()
    {
        foreach (GameObject pickUp in healthPickUps)
        {
            if (pickUp != null)
            {
                Destroy(pickUp);
            }
        }

        foreach (GameObject pickUp in ammoPickUps)
        {
            if (pickUp != null)
            {
                Destroy(pickUp);
            }
        }
    }
}
