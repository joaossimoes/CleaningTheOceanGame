using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour
{

    [SerializeField] Button[] levels;

    public static int levelsPassed;

    void Start()
    {
        
        //levelsPassed += 1;
        foreach (Button level in levels)
        {
            level.interactable = true;
            Debug.Log("quantidade de niveis passados" + levelsPassed);
            if (System.Array.IndexOf(levels,level) > levelsPassed)
            {
                level.interactable = false;
            }
        }
        
    }

    public static void AddLevelPassed()
    {
        levelsPassed+=1;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
        Debug.Log("saving...");
    }

    public void LoadGame()
    {
        Debug.Log("loading..");
        GameData data = SaveSystem.LoadGame();

        levelsPassed = data.levelsPassed;
        SaveSystem.LoadGame();
        Start();
    }

}
