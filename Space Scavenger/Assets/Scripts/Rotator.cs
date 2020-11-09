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
        if(monster)
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        
        if(pickUp)
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

            float direction = 1;

            transform.Translate(new Vector3(0, 10, 0) * direction * Time.deltaTime);

            if (transform.position.y == bobbingThreshold || transform.position.y == -bobbingThreshold)
            {
                direction = -direction;
            }
        }
    }
}

