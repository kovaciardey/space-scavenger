using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool monster;
    public bool pickUp;

    public float bobbingThreshold = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(monster) // the rotattion for monsters
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        
        if(pickUp) // the rotation for the pickups
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        }
    }
}

