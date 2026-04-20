using UnityEngine;

public class EnemyCelebrateState : IState
{
    private Enemy owner;

    public EnemyCelebrateState(Enemy owner)
    {
        this.owner = owner;
    }
    
    public void Enter()
    {
        Debug.Log("Enemy starts celebrating state");
        // Play celebrate animation.
    }

    public void Update()
    {
        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     owner.StateMachine.ChangeState(owner.PatrolState);
        // }
    }

    public void Exit()
    {
    }
}