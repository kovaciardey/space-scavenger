using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCodeParser : MonoBehaviour
{
    public GameObject startingRoom;
    public GameObject corridor;
    public GameObject roomA;
    public GameObject roomB;
    public GameObject finish;

    public GameObject levelParent;

    private Dictionary<string, GameObject> roomPrefabMap;

    private List<GameObject> roomGameObjects = new List<GameObject>();

    private LevelSceneInfo levelSceneInfo;

    private Mission levelMission;

    void Start()
    {
        levelSceneInfo = GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<LevelSceneInfo>();

        Debug.Log(levelSceneInfo.SelectedMission.ToString());

        levelMission = levelSceneInfo.SelectedMission;

        roomPrefabMap = new Dictionary<string, GameObject> {
            { "S", startingRoom },
            { "C", corridor },
            { "Ra", roomA },
            { "Rb", roomB },
            { "F", finish },
        };

        ParseLevelString();
    }

    private void ParseLevelString()
    {
        string[] roomsList = levelMission.LevelCode.Split('-');

        Vector3 position = new Vector3(0, 0, 0);

        foreach (string room in roomsList)
        {
            GameObject roomPrefab = Instantiate(roomPrefabMap[room], position, Quaternion.identity);

            position = roomPrefab.GetComponent<Room>().GetConnectorB().transform.position;

            roomPrefab.transform.parent = levelParent.transform;
        }
    }
}
