using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging
    

    //cached reference
    SceneLoader sceneloader;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if ( breakableBlocks <= 0)
        {
            WinLevel();
        }
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneloader.LoadStartScene();
    }
}
