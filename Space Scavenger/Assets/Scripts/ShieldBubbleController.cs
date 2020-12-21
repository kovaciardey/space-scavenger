using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBubbleController : MonoBehaviour
{
    public Image fill;

    public bool HasShield { get; set; }

    public void ShowFill()
    {
        fill.gameObject.SetActive(true);
    }

    public void HideFill()
    {
        fill.gameObject.SetActive(false);
    }
}
