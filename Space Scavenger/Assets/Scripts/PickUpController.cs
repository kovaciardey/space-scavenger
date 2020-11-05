using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public float lifeAdded = 20.0f;

    void Start()
    {
        //Debug.Log(gameObject.ToString() + " " + damageDealt.ToString("0.00"));
    }

    public float GetLifeAdded()
    {
        return lifeAdded;
    }

}
