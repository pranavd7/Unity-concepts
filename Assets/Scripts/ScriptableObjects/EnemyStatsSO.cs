using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStatsSO", order = 4)]
public class EnemyStatsSO : ScriptableObject
{
    public string name = "melee";
    public int maxHealth;
    public int damage;
    public int score;
    public Vector3 spawnPosition;
}
