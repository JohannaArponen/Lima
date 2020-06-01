﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour{
    public int health;
    public int numOfHearts;

    public ScoreManager sm;

    //public Image[] hearts;
    //public Sprite fullHeart;
    //public Sprite emptyHeart;



    void Update() {
        //if (health > numOfHearts) {
        //    health = numOfHearts;
        //}
        //for (int i = 0; i < hearts.Length; i++) {
        //    if(i < health) {
        //        hearts[i].sprite = fullHeart;
        //    } else {
        //        hearts[i].sprite = emptyHeart;
        //    }
        //    if(i < numOfHearts) {
        //        hearts[i].enabled = true;
        //    } else {
        //        hearts[i].enabled = false;
        //    }
        //}


    }

    public void Damaged() {
        print("Taking damage");
        health -= 1;
        sm.ChangeHealth(health);
        //if(health < numOfHearts) {
        //    numOfHearts = health;
        //}
        if(health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndGame();
    }
}
