using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int[] levelsPassedArray;

    public static List<int> levelsPassed = new List<int>(){
        0,
    };


     public static void AddLevelPassed(int levelNumber)
    {
        Debug.Log("i was here");
        levelsPassed[0] = levelNumber;

    }

    /*public GameData()
    {
        //TODO Get the game data that i want to save
        levelsPassed = 
    }*/
}
