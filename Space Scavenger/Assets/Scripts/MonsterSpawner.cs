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

    public void SpawnMonsters()
    {
        ClearMonsters();
        monsters.Clear();

        // spawn monsters at hard-coded positions
        foreach (Vector3 position in monsterPositions)
        {
            monsters.Add(Instantiate(monster, position, Quaternion.identity));
        }
    }

    // Destroys any existing monsters the spawner created so as to not get any duplicate game objects
    private void ClearMonsters()
    {
        foreach (GameObject monster in monsters)
        {
            if (monster != null)
            {
                Destroy(monster);
            }
        }
    }
}
