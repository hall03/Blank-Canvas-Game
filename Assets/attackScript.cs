using UnityEngine;

public class attackScript : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timetoAttack = 0.25f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      
            if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<PlayerMovement>().powerUp == 3)
            {
                Attack();
            }
        
            if (attacking)
            {
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
        Debug.LogError("ATTACCKING!");
    }

}
