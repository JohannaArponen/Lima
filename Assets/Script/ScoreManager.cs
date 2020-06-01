using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour{

    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    int score;
    int lifeAmount;
    
    void Start(){
        if(instance == null) {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue) {
        score += coinValue;
        scoreText.text = "X" + score.ToString();
    }

    public void ChangeHealth(int newHealth) {
        //lifeAmount -= newHealth;
        livesText.text = newHealth.ToString() + ("X" );
    }
}
