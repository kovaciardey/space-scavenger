using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCodeGenerator : MonoBehaviour
{
    public Vector2Int easyMissionLengths;
    public Vector2Int hardMissionLengths;

    private string[] selectableRooms = new string[2] { "Ra", "Rb" };

    public string GenerateLevelString(string missionType)
    {
        int iterations = 0;

        if (missionType == "Easy")
        {
            iterations = Random.Range(easyMissionLengths.x, easyMissionLengths.y);
        }
        else if (missionType == "Hard")
        {
            iterations = Random.Range(hardMissionLengths.x, hardMissionLengths.y);
        }

        string levelCode = "S-C-";

        for (int i = 0; i < iterations; i++)
        {
            string room = selectableRooms[Random.Range(0, selectableRooms.Length)];

            levelCode += room + "-C-";
        }

        levelCode += "F";

        return levelCode;
    }
}
