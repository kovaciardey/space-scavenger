using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public Text lifeText;

    void Update()
    {
        ShowLifeText();
    }

    private void ShowLifeText()
    {
        lifeText.text = "Health: " + player.GetComponent<HealthController>().GetMaxHealthValue().ToString("0.00");
    }
}
