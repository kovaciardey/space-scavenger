using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public Text lifeText;
    public Text ammoText;
    public Text scrapText;
    public Text winLoseText;
    public Text resetText;

    public GameObject reactorPrefab;
    public Vector3 reactorPosition = new Vector3(50, 0, 60);

    private GameObject reactor;
    private Color reactorInitialColor;

    private void Start()
    {
        SpawnReactor();

        winLoseText.text = "";

        resetText.gameObject.SetActive(false);

        reactorInitialColor = reactor.GetComponentInChildren<Renderer>().material.color;
    }

    void Update()
    {
        ShowLifeText();
        ShowAmmoText();
        ShowScrapText();

        if (reactor.GetComponent<ReactorController>().HasBeenClaimed)
        {
            ShowWinLoseMessage("You Win!");

            resetText.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            ResetScene();
        }
    }

    // show life
    private void ShowLifeText()
    {
        lifeText.text = "Health: " + player.GetComponent<HealthController>().GetMaxHealthValue().ToString("0.00");
    }

    // show ammo
    private void ShowAmmoText()
    {
        ammoText.text = "Ammo: " + player.GetComponent<AmmoController>().GetMaxAmmo().ToString("0");
    }

    // schow scrap
    private void ShowScrapText()
    {
        scrapText.text = "Scrap: " + player.GetComponent<ScrapController>().GetScrapAmount().ToString("0");
    }

    // show whether you wopn or lost the game
    private void ShowWinLoseMessage(string message)
    {
        winLoseText.text = message;
    }

    // spawn the win condition
    private void SpawnReactor()
    {
        reactor = Instantiate(reactorPrefab, reactorPosition, Quaternion.identity);
    }

    // reset the scene
    private void ResetScene()
    {
        winLoseText.text = "";

        reactor.GetComponent<ReactorController>().HasBeenClaimed = false;

        reactor.GetComponentInChildren<Renderer>().material.color = reactorInitialColor;

        resetText.gameObject.SetActive(false);
    }
}
