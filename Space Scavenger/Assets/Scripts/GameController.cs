using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CameraController cameraController;

    public GameObject playerPrefab;
    //public GameObject monsterSpawner;
    //public GameObject pickUpSpawner;

    public Text ammoText;
    public Text ammoClipText;
    public Text scrapText;

    public Text winLoseText;
    public Text resetText;
    public Text reloadPromptText;

    public HealthBar healthBar;
    public ReloadBar reloadBar;

    public int bubbleSpacing = 5;
    private int bubbleWidth = 30;
    public GameObject shieldBubblePrefab;
    public GameObject shieldParent;
    List<GameObject> shieldBubbles;

    //public GameObject reactorPrefab;
    //public Vector3 reactorPosition = new Vector3(50, 0, 60);

    //private GameObject reactor;
    //private Color reactorInitialColor;

    public GameObject Player { get; set; }

    private HealthController healthController;
    private ShieldController shieldController;
    private AmmoController ammoController;

    private GameObject startingRoom;
    private GameObject finishRoom;

    private void Start()
    {
        //SpawnReactor();

        winLoseText.text = "";

        resetText.gameObject.SetActive(false);
        reloadPromptText.gameObject.SetActive(false);

        //reactorInitialColor = reactor.GetComponentInChildren<Renderer>().material.color;

        startingRoom = GetComponent<LevelCodeParser>().StartingRoom;
        finishRoom = GetComponent<LevelCodeParser>().FinishRoom;

        SpawnPlayer();

        healthController = Player.GetComponent<HealthController>();
        shieldController = Player.GetComponent<ShieldController>();
        ammoController = Player.GetComponent<AmmoController>();

        cameraController.SetPlayer(Player);

        healthBar.SetMaxHealth(healthController.GetMaxHealth());
        reloadBar.SetMaxReloadValue(ammoController.reloadTime);

        UpdateHealthBar();

        shieldBubbles = new List<GameObject>();
        GenerateShieldBubbles();
    }

    void Update()
    {
        UpdateHealthBar();
        UpdateAmmoDisplay();
        UpdateScrapAmountDisplay();
        UpdateReloadBarDisplay();
        UpdateShieldBubbleDisplay();

        //if (reactor.GetComponent<ReactorController>().HasBeenClaimed)
        //{
        //    ShowWinLoseMessage("You Win!");

        //    resetText.gameObject.SetActive(true);
        //}

        if (!Player.GetComponent<PlayerController>().IsAlive)
        {
            ShowWinLoseMessage("Game Over!");

            resetText.gameObject.SetActive(true);
        }

        if (Player.GetComponent<AmmoController>().CurrentClipAmmo < 5)
        {
            reloadPromptText.gameObject.SetActive(true);
        }
        else
        {
            reloadPromptText.gameObject.SetActive(false);
        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    ResetScene();
        //}
    }

    private void GenerateShieldBubbles()
    {
        float bubbleX = 0;

        for (int i = 0; i < shieldController.maxShields; i++)
        {
            GameObject shieldBubble = Instantiate(shieldBubblePrefab, new Vector2(bubbleX, 0), Quaternion.identity);

            shieldBubble.transform.SetParent(shieldParent.transform, false);

            shieldBubbles.Add(shieldBubble);

            bubbleX += bubbleWidth + bubbleSpacing;
        }
    }

    private void UpdateShieldBubbleDisplay()
    {
        int counter = 1;

        foreach (GameObject shieldBubble in shieldBubbles)
        {
            if (counter <= shieldController.GetCurrentShields())
            {
                shieldBubble.GetComponent<ShieldBubbleController>().ShowFill();
            }
            else
            {
                shieldBubble.GetComponent<ShieldBubbleController>().HideFill();
            }

            counter += 1;
        }
    }

    // show life
    private void UpdateHealthBar()
    {
        float healthValue = healthController.GetCurrentHealth();

        healthBar.SetHealth(healthValue);
    }

    // show ammo
    private void UpdateAmmoDisplay()
    {
        ammoClipText.text = Player.GetComponent<AmmoController>().CurrentClipAmmo.ToString();
        ammoText.text = Player.GetComponent<AmmoController>().CurrentAmmo.ToString();
    }

    private void UpdateReloadBarDisplay()
    {
        reloadBar.SetCurrentReloadValue(ammoController.CurrentReloadTime);
    } 

    // schow scrap
    private void UpdateScrapAmountDisplay()
    {
        scrapText.text = Player.GetComponent<ScrapController>().GetScrapAmount().ToString("0");
    }

    // show whether you wopn or lost the game
    private void ShowWinLoseMessage(string message)
    {
        winLoseText.text = message;
    }

    private void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab, startingRoom.GetComponent<StartingRoomScript>().playerSpawnLocation.transform.position, Quaternion.identity);
    }

    // spawn the win condition
    //private void SpawnReactor()
    //{
    //    reactor = Instantiate(reactorPrefab, reactorPosition, Quaternion.identity);
    //}

    //// reset the scene
    //private void ResetScene()
    //{
    //    winLoseText.text = "";

    //    player.GetComponent<PlayerController>().IsAlive = true;
    //    player.GetComponent<HealthController>().ResetHealth();
    //    player.GetComponent<ShieldController>().ResetShields();

    //    reactor.GetComponent<ReactorController>().HasBeenClaimed = false;
    //    reactor.GetComponentInChildren<Renderer>().material.color = reactorInitialColor;

    //    monsterSpawner.GetComponent<MonsterSpawner>().SpawnMonsters();
    //    pickUpSpawner.GetComponent<PickUpSpawner>().SpawnPickUps();

    //    resetText.gameObject.SetActive(false);
    //}
}
