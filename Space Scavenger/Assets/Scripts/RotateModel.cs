﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(new Vector3 (90, 0, 0));
    }
}
