using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionJump : MonoBehaviour
{
    public bool collisionDoubleJumpTrue;
    public int powerUp;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
                collisionDoubleJumpTrue = true;
                Destroy(gameObject);
                powerUp = 1;
                collision.gameObject.GetComponent <PlayerMovement>().powerUp = 1;
            }
    }
}
