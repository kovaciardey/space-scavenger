using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * THIS SCRIPT IS UNUSED IN THE GAME AT THE MOMENT
 * 
 * Create a custom button on the editor for the monster spawner to spawn the monsters from the editor whenever
 */

//[CustomEditor (typeof (MonsterSpawner))]
public class MonsterSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MonsterSpawner spawner = (MonsterSpawner) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Spawn"))
        {
            spawner.SpawnMonsters();
        }
    }
}
