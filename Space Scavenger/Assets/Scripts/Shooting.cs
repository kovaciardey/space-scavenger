using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0.4f;

    private bool canFire;

    void Start()
    {
        canFire = true;    
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        StartCoroutine(FireRate());

        IEnumerator FireRate()
        {
            canFire = false;

            GameObject instantiatedBullet = Instantiate(bullet, transform.position, transform.rotation);
            instantiatedBullet.transform.forward = transform.forward;

            Physics.IgnoreCollision(instantiatedBullet.GetComponent<Collider>(), GetComponent<Collider>());

            yield return new WaitForSeconds(fireRate);
            canFire = true;
        }
      
    }
}
