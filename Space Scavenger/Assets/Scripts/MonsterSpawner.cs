using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;

    public Vector3[] monsterPositions;

    void Start()
    { 
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        foreach (Vector3 position in monsterPositions)
        {
            Instantiate(monster, position, Quaternion.identity);
        }
    }
}
