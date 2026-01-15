using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponSO", order = 3)]
public class WeaponSO : ScriptableObject
{
    public int damage = 10;
    public int damageScaler = 1;
    public float cooldown;

    public void Attack(GameObject target)
    {
        // Perform required operation like raycasting, dealing damage, etc.
        // if (target.TryGetComponent<Health>(out var health))
        // {
        //     health.TakeDamage(GetScaledDamage(1));
        // }
    }

    public int GetScaledDamage(int level)
    {
        return damage + damageScaler * level;
    }
}
