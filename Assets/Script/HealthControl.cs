using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour{

    public UnityEngine.UI.Text text;
    private int total;

    public int Total {
        get => total; set {
            total = value;
            UpdateHearts();
        }
    }

    void Start(){
        UpdateHearts();
    }

    void UpdateHearts(){
        text.text = total.ToString();
    }
}
