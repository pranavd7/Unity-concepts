using UnityEngine;

public class EnemyPatrolState : IState
{
    private Enemy owner;

    public EnemyPatrolState(Enemy owner)
    {
        this.owner = owner;
    }
    
    public void Enter()
    {
        // StartCooldown(owner.cooldown);
        // StartPatrol();
        Debug.Log($"Entering {owner.name}");
    }
    
    public void Update()
    {
        // Check player
        // if (playerFound)
        // {
        //     owner.OnPlayerFound();
        // }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            owner.StateMachine.ChangeState(owner.CelebrateState);
        }
    }

    public void Exit()
    {
        Debug.Log("Enemy stopped patrolling");
    }
}