using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
        
        Debug.Log($"Taking damage {damage}");
    }

    private void Die()
    {
        Debug.Log($"Character died");
    }
}