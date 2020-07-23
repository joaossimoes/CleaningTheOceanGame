using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int levelsPassed;


    public GameData(ProgressionManager progressionManager)
    {
        levelsPassed = ProgressionManager.levelsPassed;
    }
}
