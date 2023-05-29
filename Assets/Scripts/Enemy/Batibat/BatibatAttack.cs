using UnityEngine;

public class BatibatAttack : MonoBehaviour
{
    [HideInInspector] public bool isPlayerDied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float health = collision.GetComponent<PlayerHealth>().SetDamage(100f);
            if (health <= 0) isPlayerDied = true; 
        }
    }
}
