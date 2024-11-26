using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashUnlock : MonoBehaviour
{
    public bool collisionDashTrue = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionDashTrue = true;
            Destroy(gameObject);
            Debug.LogError("Can Dash!");
            collision.gameObject.GetComponent<PlayerMovement>().powerUp = 2;
        }
    }
}
