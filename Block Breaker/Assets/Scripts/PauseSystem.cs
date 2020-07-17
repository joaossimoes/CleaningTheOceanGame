﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    public static bool isPaused;

    Paddle paddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        pauseCanvas.enabled = false;
        paddle.DisableCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseCanvas.enabled = true;
    }


    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        paddle.DisableCanvas();
    }

    public void ResumeButton()
    {
        pauseCanvas.enabled = false;
        paddle.EnableCanvas();
    }
}
