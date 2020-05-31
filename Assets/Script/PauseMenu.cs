﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            if (GameIsPause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause() {
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
