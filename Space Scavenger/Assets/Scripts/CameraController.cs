﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        // simple follow camera
        transform.position = player.transform.position;
    }
}