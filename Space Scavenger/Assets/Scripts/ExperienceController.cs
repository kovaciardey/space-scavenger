using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    public int experiencePerKill = 15;

    public int GatheredExperience { get; set; }

    private void Start()
    {
        GatheredExperience = 0;
    }

    public void AddExperience()
    {
        GatheredExperience += experiencePerKill;

        Debug.Log(GatheredExperience);
    }
}
