using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject backToShipButton;
    public GameObject saveGameButton;

    public void ShowShipSceneButtons()
    {
        backToShipButton.gameObject.SetActive(false);
        saveGameButton.gameObject.SetActive(true);
    }

    public void ShowLevelSceneButtons()
    {
        backToShipButton.gameObject.SetActive(true);
        saveGameButton.gameObject.SetActive(false);
    }
}
