using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    void LateUpdate()
    {
        if (player != null)
        {
            // simple follow camera
            transform.position = player.transform.position;
        }
    }

    public void SetPlayer(GameObject playerObject)
    {
        player = playerObject;
    } 
}