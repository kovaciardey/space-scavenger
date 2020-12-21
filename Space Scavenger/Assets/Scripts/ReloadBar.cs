using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxReloadValue(float reloadTime)
    {
        slider.maxValue = reloadTime;
        slider.value = reloadTime;
    }

    public void SetCurrentReloadValue(float reloadTime)
    {
        slider.value = reloadTime;
    }
}
