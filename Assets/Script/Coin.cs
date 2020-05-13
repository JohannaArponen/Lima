using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{

    public int points = 100;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<PointControl>().Points += points;
            Destroy(gameObject);
        }
    }
}
