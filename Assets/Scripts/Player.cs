using System;
using UnityEngine;
using VehicleSystem;

public delegate void PlayerDied();

public class Player : MonoBehaviour, ICharacter, IDamageable, IHealable
{

    // [SerializeField] GameManager gameManager;

    [SerializeField] AudioClip clip;
    
    private float currentHealth = 100;
    private float armorDamageReduction = 20;
    
    public static event PlayerDied OnPlayerDeath;
    
    [SerializeField] 
    

    public void Start()
    {
        GameManager.Instance.AddScore(10);
        AudioManager.Instance.PlaySFX(clip);

        // FileManager.Instance.ReadFile("savepath"); 

        Car car = new Car(10, 2, true);
        
        ((Vehicle)car).Move();


        GameEvents.OnGameLoaded += OnGameLoaded;
    }

    private void OnGameLoaded(PlayerData data)
    {
        currentHealth = data.health;
        
    }

    public string Name { get; set; }
    public event Action OnDeath;
    public void Interact(int amount)
    {
        Debug.Log($"Interacting with player");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player Taking damage {damage}");
        currentHealth -= damage * (1 - armorDamageReduction / 100);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"Player {Name} is dead");
    }

    public void Heal(int amount)
    {
        currentHealth += 2 * amount;
    }
}