using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackUnlock : MonoBehaviour
{
    public bool collisionAttackTrue = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionAttackTrue = true;
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMovement>().powerUp = 3;
        }
    }
}
