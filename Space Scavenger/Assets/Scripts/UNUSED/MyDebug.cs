using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS NOT USED

// litle script that I can apply to elements to gat various information about them
// at the moment it only returns the game object with the tag

public class MyDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.ToString() + " " + gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
