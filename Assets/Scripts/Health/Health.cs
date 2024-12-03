using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float startingDamage;
    public float invulTime = 1f; // The time you stay invulnerable after a hit
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool invulnerable = false;
    private bool dead;


    private void Awake()
    {
        currentHealth = startingHealth;
        TakeDamage(startingDamage);
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float _damage)
    {
        if (!invulnerable)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            StartCoroutine(JustHurt());
        }

        if (currentHealth > 0)
        {
            if (anim != null)
            {
                anim.SetBool("hurt", true);//player hurt
            }
        }
        else
        {
            if (!dead)//player dead
            {
                Destroy(gameObject);
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    IEnumerator JustHurt()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;

    }
}

