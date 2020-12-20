using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public Vector2Int shortExpReward;
    public Vector2Int longExpReward;
    public Vector2Int shortScrapReward;
    public Vector2Int longScrapReward;

    private string LevelCode { get; }

    public int ExpReward { get; }
    public int ScrapReward { get; }

    private string MissionType { get; }

    private int MissionID { get; set; }

    public Mission()
    {
        MissionType = "Short";

       ExpReward = GenerateExpReward();
    }

    public void GenerateMissionDetails(string missionType, int missionID)
    {

    }

    private int GenerateExpReward()
    {
        if (this.MissionType == "Long")
        {
            return Random.Range(longExpReward.x, longExpReward.y);
        }

        return Random.Range(25, 45);
    }

    public override string ToString()
    {
        return "HERE IS MISSION";
    }
}
