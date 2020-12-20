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

    private Mission Mission { get; set; }

    private ShipSceneController shipSceneController;

    void Start()
    {
        Mission = new Mission();

        shipSceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ShipSceneController>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        shipSceneController.SetSelectedMission(Mission);
    }
}
