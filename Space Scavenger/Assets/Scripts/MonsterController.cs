using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float damageDealt; // damage dealt to player

    private GameObject player;

    void Start()
    {
        // randomly generate the damage value
        damageDealt = Random.Range(10.0f, 20.0f);

        // keeping a reference of the player object on each monster for the scrap adding.
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public float GetDamage()
    {
        return damageDealt;
    }

    public void DestroyMonster(bool killedbyPlayer)
    {
        gameObject.GetComponent<SpawnPickUpOnKill>().SpawnPickUp();

        if (killedbyPlayer)
        {
            player.GetComponent<ScrapController>().AddScrap(gameObject.GetComponent<ScrapSpawner>().GetScrapToDrop());
            player.GetComponent<ExperienceController>().AddExperience();
        }

        Destroy(gameObject);
    }
}
