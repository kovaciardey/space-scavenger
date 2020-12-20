using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MissionPanelController : MonoBehaviour, ISelectHandler
{
    public Text missionIdText;
    public Text missionDifficultyText;

    public Text expText;
    public Text scrapText;

    public Mission Mission { get; set; }

    private ShipSceneController shipSceneController;

    void Start()
    {
        shipSceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ShipSceneController>();
    }

    void Update()
    {
        UpdatePanelTexts();
    }

    public void OnSelect(BaseEventData eventData)
    {
        shipSceneController.SetSelectedMission(Mission);
    }

    private void UpdatePanelTexts()
    {
        missionIdText.text = Mission.ID.ToString();
        missionDifficultyText.text = Mission.Difficulty;

        expText.text = Mission.ExpReward.ToString();
        scrapText.text = Mission.ScrapReward.ToString();
    }
}
