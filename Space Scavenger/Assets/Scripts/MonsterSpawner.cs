using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;

    public Vector3[] monsterPositions;

    private List<GameObject> monsters;

    void Start()
    {
        monsters = new List<GameObject>();

        SpawnMonsters();
    }

    private void Update()
    {   
        if (Input.GetButtonDown("Jump"))
        {
            SpawnMonsters();
        }
    }

    public void SpawnMonsters()
    {
        monsters.Clear();

        // spawn monsters at hard-coded positions
        foreach (Vector3 position in monsterPositions)
        {
            monsters.Add(Instantiate(monster, position, Quaternion.identity));
        }
    }
}
