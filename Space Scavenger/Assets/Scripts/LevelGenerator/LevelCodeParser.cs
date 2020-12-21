using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCodeParser : MonoBehaviour
{
    private LevelSceneInfo levelSceneInfo;

    void Start()
    {
        levelSceneInfo = GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<LevelSceneInfo>();

        Debug.Log(levelSceneInfo.SelectedMission.ToString());
    }
}
