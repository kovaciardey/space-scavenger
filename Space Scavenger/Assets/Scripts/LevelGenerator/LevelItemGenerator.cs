using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemGenerator : MonoBehaviour
{
    public GameObject[] pickUps;

    public void GenerateItems()
    {
        foreach (GameObject room in GetComponent<LevelCodeParser>().roomGameObjects)
        {
            if (room.GetComponent<Room>().RoomType == "S")
            {
                foreach(GameObject pickUpLocation in room.GetComponent<StartingRoomScript>().pickUpLocations)
                {
                    GameObject pickUp = GetRandomPickUpType();

                    Instantiate(pickUp, pickUpLocation.transform);
                } 
            }
        }
    }

    private GameObject GetRandomPickUpType()
    { 
        return pickUps[Random.Range(0, pickUps.Length)];
    }
}
