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
            else if (room.GetComponent<Room>().RoomType == "C")
            {
                if (GetComponent<LevelCodeParser>().LevelMission.Difficulty == "Easy")
                {
                    Instantiate(GetRandomPickUpType(), room.GetComponent<CorridorScript>().pickUpLocation.transform);
                } 
                else if (GetComponent<LevelCodeParser>().LevelMission.Difficulty == "Hard")
                {
                    // spawn the pickup with a rate
                    if (Random.value <= room.GetComponent<CorridorScript>().spawnRate)
                    {
                        Instantiate(GetRandomPickUpType(), room.GetComponent<CorridorScript>().pickUpLocation.transform);
                    }
                }
            } 
        }
    }

    private GameObject GetRandomPickUpType()
    { 
        return pickUps[Random.Range(0, pickUps.Length)];
    }
}
