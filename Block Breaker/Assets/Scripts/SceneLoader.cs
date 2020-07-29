using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Cursor.visible = true;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
        Cursor.visible = true;
    }

    public void LoadWorldMap()
    {
        SceneManager.LoadScene("World Map");
        Cursor.visible = true;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1-1");
    }
    
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 1-2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 1-3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 1-4");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
