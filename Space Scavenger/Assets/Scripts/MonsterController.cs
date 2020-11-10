using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float damageDealt; // damage dealt to player

    void Start()
    {
        // randomly generate the damage value
        damageDealt = Random.Range(10.0f, 20.0f);
    }

    public float GetDamage()
    {
        return damageDealt;
    }

}
