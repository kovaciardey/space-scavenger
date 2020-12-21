using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0.4f;

    private bool canFire;

    void Start()
    {
        canFire = true;
    }

    public void Shoot()
    {
        StartCoroutine(FireRate());

        IEnumerator FireRate()
        {
            canFire = false;

            GameObject instantiatedBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
            instantiatedBullet.GetComponent<BulletController>().SetOwner(gameObject);
            instantiatedBullet.transform.forward = transform.forward;

            yield return new WaitForSeconds(fireRate);
            canFire = true;
        }
    }

    public bool GetCanFire()
    {
        return canFire;
    }
}
