using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    private Vector2Int shortExpReward = new Vector2Int(25, 45);
    public Vector2Int longExpReward = new Vector2Int(60, 85);
    public Vector2Int shortScrapReward = new Vector2Int(100, 170);
    public Vector2Int longScrapReward = new Vector2Int(250, 325);

    public string LevelCode { get; set; }

    public int ExpReward { get; }
    public int ScrapReward { get; }

    public string Difficulty { get; }

    public int ID { get; set; }

    public Mission(int id)
    {
        this.ID = id;

        Difficulty = GenerateMissionDifficulty();

        ExpReward = GenerateExpReward();
        ScrapReward = GenerateScrapReward();
    }

    private string GenerateMissionDifficulty()
    {
        if (Random.value >= 0.8)
        {
            return "Hard";
        }

        return "Easy";
    }

    private int GenerateScrapReward()
    {
        if (this.Difficulty == "Hard")
        {
            return Random.Range(longScrapReward.x, longScrapReward.y);
        }

        return Random.Range(shortScrapReward.x, shortScrapReward.y);
    }

    private int GenerateExpReward()
    {
        if (this.Difficulty == "Hard")
        {
            return Random.Range(longExpReward.x, longExpReward.y);
        }

        return Random.Range(shortExpReward.x, shortExpReward.y);
    }

    public override string ToString()
    {
        return "(" + ID + " - " + Difficulty + " - EXP: " + ExpReward + ", SCR: " + ScrapReward + ", CODE: " + LevelCode + ")";
    }
}
