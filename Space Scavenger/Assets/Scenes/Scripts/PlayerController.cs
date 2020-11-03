using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);

        GetComponent<Transform>().Translate(movement * speed * Time.deltaTime);
    }


}
