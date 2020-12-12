using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject connectorA;
    public GameObject connectorB;

    public GameObject GetConnectorA() {
        return connectorA;
    }

    public GameObject GetConnectorB()
    {
        return connectorB;
    }
}
