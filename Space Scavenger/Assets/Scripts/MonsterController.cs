using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float damageDealt;

    void Start()
    {
        damageDealt = Random.Range(10.0f, 20.0f);
        //Debug.Log(gameObject.ToString() + " " + damageDealt.ToString("0.00"));
    }

    public float GetDamage()
    {
        return damageDealt;
    }

}
