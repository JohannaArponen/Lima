﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
  
     public void EndGame() {
        Debug.Log("GAME OVER");
    }
   
}
