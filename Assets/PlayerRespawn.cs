using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 respawnPoint;

    public void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    private void Dead()
    {
        if(gameObject.GetComponent<Health>().currentHealth == 0)
        {
            Health health = GetComponent<Health>();
            RespawnNow();
            health.AddHealth(3);
        }
    }



}
