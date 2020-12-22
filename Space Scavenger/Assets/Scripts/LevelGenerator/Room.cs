using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject connectorA;
    public GameObject connectorB;

    public string RoomType { get; set; }

    public GameObject GetConnectorA() {
        return connectorA;
    }

    public GameObject GetConnectorB()
    {
        return connectorB;
    }

    public void DestroyConnectors()
    {
        Destroy(connectorA);
        Destroy(connectorB);
    }


}
