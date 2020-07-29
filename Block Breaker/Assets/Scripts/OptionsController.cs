using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;


    
    // Start is called before the first frame update
    void Start()
    {  
        volumeSlider.value = PlayerPrefsController.GetVolume();
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        FindObjectOfType<SceneLoader>().LoadStartScene();
    }
}
