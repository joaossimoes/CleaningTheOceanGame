using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour
{

    [SerializeField] Button[] levels;

    
    List<int> unlockedLevels;

    /*void Awake()
    {
        ProgressionManager[] objs = FindObjectsOfType<ProgressionManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }    

        DontDestroyOnLoad(this.gameObject);
    }*/


    void Start()
    {
        foreach (Button level in levels)
        {
            Debug.Log("index do level" + System.Array.IndexOf(levels,level));
            Debug.Log("valor nos passados" + GameData.levelsPassed[0]);
            if (System.Array.IndexOf(levels,level) > GameData.levelsPassed[0]-2)
            {
                level.interactable = false;
            }
        }
        
    }

    //TODO Unlock the buttons that should be unlocked

   

    /*
    
    

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levels.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levels[i].interactable = false; 
            }
            
        }

    }  */
}
