using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLife = 2.0f;
    public float bulletSpeed = 100f;

    private LineRenderer lineRenderer;

    public void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    public void FixedUpdate()
    {
        // move the bullet forward 
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);

        DebugForward();
        Destroy(gameObject, bulletLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        // destroy if hit monster
        if (other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<SpawnPickUpOnKill>().SpawnPickUp();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Crate")
        {
            Debug.Log("HERE");

            other.gameObject.GetComponent<SpawnPickUpOnKill>().SpawnPickUp();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // destroy the bullet if out of bounds
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    private void DebugForward()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * 4);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }
}
