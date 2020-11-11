using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnSight : MonoBehaviour
{
    public float minDistance = 30f;

    private GameObject target;

    // The Monsters are quite simplistic at the moment.
    // They will be upgraded with a simple AI and some pathfinding mechaninc
    // At the moment thery just look at the player if he is in their range
    // and it will shoot a bullet.

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= minDistance && GetComponent<Shooting>().GetCanFire())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        transform.LookAt(target.transform);

        GetComponent<Shooting>().Shoot();
    }
}
