using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStatsSO", order = 4)]
public class EnemyStatsSO : ScriptableObject
{
    public string name = "melee";
    public int maxHealth;
    public int damage;
    public float modifier = 0.2f;
    public int score;
    public Vector3 spawnPosition;
    public string animName;

    public float GetDamage()
    {
        return damage * modifier;
    }

    public float GetHealth(float modifier)
    {
        return maxHealth * modifier;
    }
}
