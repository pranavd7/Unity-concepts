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

    public void Save()
    {
        string data = "playname,10,100,300.05";
        
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetFloat("MaxHealth", maxHealth);
        PlayerPrefs.SetString("Savedata", data);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        int health = PlayerPrefs.GetInt("Health", 0);
        float float1 = PlayerPrefs.GetFloat("MaxHealth", 100f);
        string name1 = PlayerPrefs.GetString("Name", gameObject.name);
        
        string data = PlayerPrefs.GetString("Savedata", "");
        string[] datavalues = data.Split(',');
        string name2 = datavalues[0];
        currentHealth = int.Parse(datavalues[1]);
        maxHealth = int.Parse(datavalues[2]);
        float xp = float.Parse(datavalues[3]);
    }
}