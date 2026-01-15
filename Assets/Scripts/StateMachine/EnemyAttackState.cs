using UnityEngine;

public class EnemyAttackState : IState
{
    public void Enter()
    {
        Debug.Log("Enemy starts attack");
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