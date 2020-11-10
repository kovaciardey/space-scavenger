using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public Text lifeText;
    public Text ammoText;

    void Update()
    {
        ShowLifeText();
        ShowAmmoText();
    }

    private void ShowLifeText()
    {
        lifeText.text = "Health: " + player.GetComponent<HealthController>().GetMaxHealthValue().ToString("0.00");
    }

    private void ShowAmmoText()
    {
        ammoText.text = "Ammo: " + player.GetComponent<AmmoController>().GetMaxAmmo().ToString("0");
    }
}
