using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float startingDamage;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;


    private void Awake()
    {
        currentHealth = startingHealth;
        TakeDamage(startingDamage);
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth=Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);

        if (currentHealth > 0)
        {
           anim.SetTrigger("hurt");//player hurt
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
        currentHealth=Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

}

