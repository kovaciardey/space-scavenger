using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
