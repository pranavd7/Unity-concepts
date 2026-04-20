using System;
using UnityEngine;

public class NPCCharacter : MonoBehaviour, ICharacter, IDamageable
{
    private int maxHealth = 100;
    private int currentHealth;


    [SerializeField] private string m_name;
    public string Name { get => name; set => name = value; }

    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Interact(int amount)
    {
        Debug.Log($"Interacted with character: {Name}");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Taking damage {damage}");
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"Character died");
    }
}