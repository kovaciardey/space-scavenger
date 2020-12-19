using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxExp(float experience)
    {
        slider.maxValue = experience;
        slider.value = experience;
    }

    public void SetExp(float experience)
    {
        slider.value = experience;
    }
}
