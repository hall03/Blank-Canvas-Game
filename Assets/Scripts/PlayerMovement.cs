using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool doubleJump;

    public int powerUp = 0;

    private void Awake()
    {   
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
 
        //Flip player face
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
            }
            else if (powerUp == 1 && doubleJump)
            {
                Jump();
                doubleJump = false;
            }
        }

        if (grounded)
        {
            doubleJump = true;
        }
 
        //Animation
        anim.SetBool("run", horizontalInput != 0);

        //Adjustable jump
        if(Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y >0)
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y / 2);
    }
 
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}