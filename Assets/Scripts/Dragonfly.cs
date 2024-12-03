using UnityEngine;

public class Dragonfly : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
                FlipSprite(); // Flip when changing direction
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
                FlipSprite(); // Flip when changing direction
            }
        }
    }

    private void FlipSprite()
    {
        // Determine the correct facing direction
        Vector3 localScale = transform.localScale;
        if (movingLeft)
        {
            localScale.x = Mathf.Abs(localScale.x); // Ensure positive x-scale when facing left
        }
        else
        {
            localScale.x = -Mathf.Abs(localScale.x); // Ensure negative x-scale when facing right
        }
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }
}