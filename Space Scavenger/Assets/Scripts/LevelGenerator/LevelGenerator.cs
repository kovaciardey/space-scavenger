using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int minLevelLength = 2;
    public int maxLevelLength = 6;

    public GameObject startingRoom;
    public GameObject corridor;
    public GameObject roomA;
    public GameObject roomB;
    public GameObject finish;

    public GameObject levelParent;

    private string levelCode;

    private string[] selectableRooms = new string[2] { "Ra", "Rb" };

    private Dictionary<string, GameObject> roomPrefabMap;

    private List<GameObject> roomGameObjects = new List<GameObject>();

    public void GenerateLevel()
    {
        GenerateLevelString();

        roomPrefabMap = new Dictionary<string, GameObject> {
            { "S", startingRoom },
            { "C", corridor },
            { "Ra", roomA },
            { "Rb", roomB },
            { "F", finish },
        };

        ParseLevelString();
    }

    private void GenerateLevelString()
    {
        int iterations = Random.Range(minLevelLength, maxLevelLength);

        levelCode = "S-C-";

        for (int i = 0; i < iterations; i++)
        {
            string room = selectableRooms[Random.Range(0, selectableRooms.Length)];

            levelCode += room + "-C-";
        }

        levelCode += "F";

        Debug.Log(levelCode);
    }

    private void ParseLevelString()
    {
        string[] roomsList = levelCode.Split('-');

        Vector3 position = new Vector3(0, 0, 0);

        foreach (string room in roomsList)
        {
            GameObject roomPrefab = Instantiate(roomPrefabMap[room], position, Quaternion.identity);

            position = roomPrefab.GetComponent<Room>().GetConnectorB().transform.position;

            roomPrefab.transform.parent = levelParent.transform;
        } 
    }
}
