using UnityEngine;

public class attackScript : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    public float timetoAttack = 0.25f;
    public float timer = 0f;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<PlayerMovement>().powerUp == 3)
            {
                Attack();
            }
        
            if (attacking)
            {
            anim.SetTrigger("photo");
            timer += Time.deltaTime;

            if (timer >= timetoAttack)
                {
                    timer = 0;
                    attacking = false;
                    attackArea.SetActive(attacking);
                }
            }
        
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

}
