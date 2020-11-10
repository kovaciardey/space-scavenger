using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public float lifeAdded = 20.0f; // life added by the pickup

    public float GetLifeAdded()
    {
        return lifeAdded;
    }

}
