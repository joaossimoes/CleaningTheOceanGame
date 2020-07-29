using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";


    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;


    public static void SetVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("master volume set to" + volume);
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("volume is out of range");
        }
    }


    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

}
