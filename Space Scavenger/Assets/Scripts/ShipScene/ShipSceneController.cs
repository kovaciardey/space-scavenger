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

    private void Start()
    {
        experienceBar.SetMaxExp(maxExp);
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

    private void ShowScrapAmountText()
    {
        scrapAmountText.text = "Scrap: " + scrap;
    }

    private void UpdateLevelAndExperience()
    {
        levelText.text = level.ToString();

        experienceBar.SetExp(exp);
    } 
}
