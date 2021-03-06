﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private bool canHide = false;
    private bool hiding = false;
    public SpriteRenderer rend;

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

        if (canHide && Input.GetKeyDown(KeyCode.H)) {
            print("H nappi painettu");
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 0;
            hiding = true;
        } 
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnDamage() {
        animator.SetBool("IsDamage", false);
    }

    void FixedUpdate() {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
       /* if (!hiding)
            horizontalMove = new Vector2(controller.Move, horizontalMove.y);
        else
            horizontalMove = Vector2.zero;*/
    }

    private void OnTriggerEnter2D(Collider2D others) {
        if (others.gameObject.tag == "piilo") {
            canHide = true;
        }
        /*if (other.gameObject.CompareTag("Coins")) {
            Destroy(other.gameObject);
        }*/
    }

    private void OnTriggerExit2D(Collider2D others) {
        if (others.gameObject.tag == "piilo") {
            canHide = false;
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 3;
            hiding = false;
        }
    }
}
