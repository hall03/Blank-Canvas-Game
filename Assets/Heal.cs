using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float heal;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.AddHealth(heal);
            Destroy(gameObject);
            
        }
    }
}
