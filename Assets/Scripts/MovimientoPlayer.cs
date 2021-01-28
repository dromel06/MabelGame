using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoPlayer : MonoBehaviour
{
    SpriteRenderer sprRender;
    //Animator myAnim;
    Rigidbody2D myRB;
    public float maxSpeed;
    bool grounded;
    float groundCheckRadius;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;


    void Start() {
        //myAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        maxSpeed = 3f;
        grounded = false;
        groundCheckRadius = 0.01f;
        sprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //esto se encarga de controlar la velocidad del personaje
        if (horizontal < 0f || horizontal > 0f){
            myRB.velocity = new Vector2(horizontal * maxSpeed, myRB.velocity.y);
          //  myAnim.SetBool("quieto", false);
            if(horizontal > 0f){
                sprRender.flipX = false;
            }
            else {
                sprRender.flipX = true;
            }
        }
        else
        {
           // myAnim.SetBool("quieto", true);
            myRB.velocity = new Vector2(0, myRB.velocity.y);
        }

        if (grounded && Input.GetKeyDown("space")){
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }
        

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
