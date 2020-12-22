using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCodeParser : MonoBehaviour
{
    public GameObject startingRoomPrefab;
    public GameObject corridor;
    public GameObject roomA;
    public GameObject roomB;
    public GameObject finishPrefab;

    public GameObject levelParent;

    public GameObject StartingRoom { get; set; }
    public GameObject FinishRoom { get; set; }

    private Dictionary<string, GameObject> roomPrefabMap;

    public List<GameObject> roomGameObjects = new List<GameObject>();

    private LevelSceneInfo levelSceneInfo;

    private Mission levelMission;

    void Awake()
    {
        levelSceneInfo = GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<LevelSceneInfo>();

        //Debug.Log(levelSceneInfo.SelectedMission.ToString());

        levelMission = levelSceneInfo.SelectedMission;

        roomPrefabMap = new Dictionary<string, GameObject> {
            { "S", startingRoomPrefab },
            { "C", corridor },
            { "Ra", roomA },
            { "Rb", roomB },
            { "F", finishPrefab },
        };

        ParseLevelString();

        GetComponent<LevelItemGenerator>().GenerateItems();
    }

    private void ParseLevelString()
    {
        string[] roomsList = levelMission.LevelCode.Split('-');

        Vector3 position = new Vector3(0, 0, 0);

        foreach (string room in roomsList)
        {
            GameObject roomPrefab = Instantiate(roomPrefabMap[room], position, Quaternion.identity);
            position = roomPrefab.GetComponent<Room>().GetConnectorB().transform.position;
            roomPrefab.GetComponent<Room>().RoomType = room;

            if (room == "S")
            {
                StartingRoom = roomPrefab;
            }

            if (room == "F")
            {
                FinishRoom = roomPrefab;
            }

            roomPrefab.transform.parent = levelParent.transform;

            roomGameObjects.Add(roomPrefab);
        }
    }
}
