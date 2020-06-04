using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour{
    public int health;
    public int numOfHearts;

    public ScoreManager sm;
    public Animator animator;
    public Rigidbody2D rb;
    public float speed;
  

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

    public void Damaged(Vector3 enemyPos) {
        print("Taking damage");
        Knockback(enemyPos);
        health -= 1;
        sm.ChangeHealth(health);
        //if(health < numOfHearts) {
        //    numOfHearts = health;
        //}
        animator.SetBool("IsDamage", true);
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndGame();
    }

    void Knockback(Vector3 enemyPos) {
        var p = transform.position;
        var E = enemyPos;
        var t = p - E;
        t.y = 0;
        t.Normalize();
        t += Vector3.up;
        t.Normalize();
        rb.AddForce(t * speed, ForceMode2D.Impulse);//.Add force(t * speed, forcenode.Impulse);
    }
}
