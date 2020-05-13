using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour{

    public UnityEngine.UI.Text text;
    private int points;

    public int Points {
        get => points; set {
            points = value;
            UpdatePoints();
        }
    }
    
    void Start(){
        UpdatePoints();
    }

    
    void UpdatePoints(){
        text.text = points.ToString();
    }
}
