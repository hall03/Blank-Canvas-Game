using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;
    [SerializeField] private float secondjumpheight;
    [SerializeField] private float maxVelocity;
    //[SerializeField] private float spriteSize;
    private Rigidbody2D body;
    private Animator anim;
    public bool grounded;
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

        //creates max gravity velocity
        body.linearVelocity = Vector3.ClampMagnitude(body.linearVelocity, maxVelocity);

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
                Jump(jumpheight);
            }
            else if (powerUp >= 2 && doubleJump)
            {
                GetComponent<Animator>().SetTrigger("2d 0");
                Jump(secondjumpheight);
                doubleJump = false;
            }
        }

        if (grounded)
        {
            doubleJump = true;
        }


 
        //Animation
        anim.SetBool("run", horizontalInput != 0);
        anim.SetFloat("xVelocity", Math.Abs(body.linearVelocity.x));
        anim.SetFloat("yVelocity", (body.linearVelocity.y));

        //Adjustable jump
        if(Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y >0)
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y / 2);
    }
 
    private void Jump(float jumpheight)
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpheight);
        grounded = false;
        anim.SetBool("jump", !grounded);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
        anim.SetBool("jump", !grounded);
    }

}