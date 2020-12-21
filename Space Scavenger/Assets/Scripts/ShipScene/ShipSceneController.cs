using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSceneController : MonoBehaviour
{
    public int scrap = 1000;

    public int exp = 0;
    public int maxExp = 100;
    public int level = 1;

    public Text scrapAmountText;
    public Text levelText;

    public ExperienceBar experienceBar;

    public GameObject missionPanelPrefab;
    public GameObject missionPanelParent;

    public Vector2[] missionPanelLocations;

    private Mission SelectedMission;

    private List<Mission> missions;

    private void Start()
    {
        experienceBar.SetMaxExp(maxExp);

        SelectedMission = null;

        missions = new List<Mission>();

        GenerateMissions();

        ShowMissionsOnScreen();
    }

    private void Update()
    {
        ShowScrapAmountText();
        UpdateLevelAndExperience();
    }

    public void AddScrap(int amount)
    {
        scrap += amount;
    }

    public void AddExperience(int amount)
    {
        if ((exp + amount) == maxExp)
        {
            exp = 0;
            level += 1;
        }
        else if ((exp + amount) > maxExp)
        {
            int difference = exp + amount - maxExp;

            level += 1;

            exp = difference;
        }
        else
        {
            exp += amount;
        }
    }

    public void LaunchMission()
    {
        if (SelectedMission == null)
        {
            Debug.Log("No Selected Mission");
        }
        else
        {
            Debug.Log(SelectedMission.ToString());
        }
    }

    public void SetSelectedMission(Mission mission)
    {
        SelectedMission = mission;
    }

    private void GenerateMissions()
    {
        if (missions.Count > 0)
        {
            missions.Clear();
        }

        for (int i = 1; i <= 3; i++)
        {
            Mission mission = new Mission(i);
            mission.LevelCode = GetComponent<LevelCodeGenerator>().GenerateLevelString(mission.Difficulty);

            missions.Add(mission);
        }
    }

    private void ShowMissionsOnScreen()
    {
        int positionCounter = 0;
        foreach (Mission mission in missions)
        {
            GameObject missionPanel = Instantiate(missionPanelPrefab, missionPanelLocations[positionCounter], Quaternion.identity);

            missionPanel.transform.SetParent(missionPanelParent.transform, false);
            missionPanel.GetComponent<MissionPanelController>().Mission = mission;

            positionCounter += 1;
        }
    }

    private void ShowScrapAmountText()
    {
        scrapAmountText.text = scrap.ToString();
    }

    private void UpdateLevelAndExperience()
    {
        levelText.text = level.ToString();

        experienceBar.SetExp(exp);
    } 
}
