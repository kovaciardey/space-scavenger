using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLife = 2.0f;
    public float bulletSpeed = 100f;

    public float bulletDamage = 20.0f;

    private LineRenderer lineRenderer;

    private GameObject owner = null;

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

    public GameObject GetOwner()
    {
        return owner;
    }

    public void SetOwner(GameObject bulletOwner)
    {
        owner = bulletOwner;
    }

    public float GetBulletDamage()
    {
        return bulletDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        // apply damage to the monster health
        if (other.gameObject.tag == "Monster")
        {
            bool isPLayerOwner = (owner.tag == "Player");

            other.gameObject.GetComponent<HealthController>().ApplyDamage(gameObject.GetComponent<BulletController>().GetBulletDamage());

            if (other.gameObject.GetComponent<HealthController>().GetCurrentHealth() == 0)
            {
                other.gameObject.GetComponent<MonsterController>().DestroyMonster(isPLayerOwner);
            }
            
            Destroy(gameObject);
        }

        // the crates will have some more functionality but at the moment they just act as barriers and will destroy bullets on contact
        if (other.gameObject.tag == "Crate")
        {
            //Debug.Log("HERE");

            //other.gameObject.GetComponent<SpawnPickUpOnKill>().SpawnPickUp();

            //Destroy(other.gameObject);
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
