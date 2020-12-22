using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemGenerator : MonoBehaviour
{
    public GameObject[] pickUps;

    public GameObject monsterPrefab;

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
            else if (room.GetComponent<Room>().RoomType == "F")
            {

            }
            else
            {
                {
                    Instantiate(GetRandomPickUpType(), room.GetComponent<IntermediaryRoomScript>().pickUpLocation.transform);
                }

                if (GetComponent<LevelCodeParser>().LevelMission.Difficulty == "Easy")
                {
                    foreach (GameObject monsterLocation in room.GetComponent<IntermediaryRoomScript>().easyMonsterLocations)
                    {
                        Instantiate(monsterPrefab, monsterLocation.transform);
                    }
                }
                else if (GetComponent<LevelCodeParser>().LevelMission.Difficulty == "Hard")
                {
                    foreach (GameObject monsterLocation in room.GetComponent<IntermediaryRoomScript>().hardMonsterLocations)
                    {
                        Instantiate(monsterPrefab, monsterLocation.transform);
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
