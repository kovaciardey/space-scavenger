using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public int iterations = 4;

    private Dictionary<string, string[]> roomPossibleConnections = new Dictionary<string, string[]> {
        { "S", new string[2] { "Ra", "Rb" } },
        { "Ra", new string[3] { "Ra", "Rb", "F" } },
        { "Rb", new string[3] { "Ra", "Rb", "F" } }
    };

    public void GenerateLevel()
    { 
        string levelCode = "S-";

        string currentRoom = levelCode[0].ToString();

        Debug.Log(roomPossibleConnections[currentRoom]);

        for (int i = 0; i < iterations; i++)
        {
            Debug.Log(i);

            string[] rooms = roomPossibleConnections[currentRoom];

            string selectedRoom = rooms[Random.Range(0, rooms.Length)];

            levelCode += selectedRoom + "-";

            currentRoom = selectedRoom;

            if (currentRoom == "F")
            {
                break;
            }
        }

        Debug.Log(levelCode);
    }
}
