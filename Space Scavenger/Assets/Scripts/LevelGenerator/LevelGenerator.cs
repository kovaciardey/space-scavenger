using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int minLevelLength = 2;
    public int maxLevelLength = 6;

    public Dictionary<string, string> dict = new Dictionary<string, string>();

    private string[] selectableRooms = new string[2] { "Ra", "Rb" };

    public void GenerateLevel()
    {
        int iterations = Random.Range(minLevelLength, maxLevelLength);

        string levelCode = "S-C-";

        for (int i = 0; i < iterations; i++)
        {
            string room = selectableRooms[Random.Range(0, selectableRooms.Length)];

            levelCode += room + "-C-";
        }

        levelCode += "F";

        Debug.Log(levelCode);
    }
}
