using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAttackState : IState
{
    [SerializeField] private Enemy enemy;
    
    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    
    
    public void Enter()
    {
        Debug.Log($"Enemy starts attack {enemy.flashColor}");
    }

    public void Update()
    {
        // Attack logic...+
        Debug.Log("Enemy attacking...");
    }

    public void Exit()
    {
        Debug.Log("Enemy stops attack");
    }
}