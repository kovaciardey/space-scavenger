using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (LevelGenerator))]
public class LevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelGenerator levelGenerator = (LevelGenerator) target;

        //base.OnInspectorGUI();

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            levelGenerator.GenerateLevel();
        }
    }
}
