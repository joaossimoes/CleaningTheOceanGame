using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour
{

    [SerializeField] Button[] levels;
    [SerializeField] GameObject[] images;

    public static int levelsPassed;



    void Start()
    {
        if (levels.Length > 0)
        {
            ButtonsUnlock();
            ImagesUnlock();
        }
    }


    private void ImagesUnlock()
    {
        foreach(GameObject image in images)
        {
            image.SetActive(true);
            if (System.Array.IndexOf(images, image) > levelsPassed - 1)
            {
                image.SetActive(false);
            }
        }
    }

    private void ButtonsUnlock()
    {
        //levelsPassed += 1;
        foreach (Button level in levels)
        {
            level.interactable = true;
            if (System.Array.IndexOf(levels, level) > levelsPassed)
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
