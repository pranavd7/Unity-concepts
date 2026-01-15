using UnityEngine;

public class EnemyIdleState : State<Enemy>
{
    public EnemyIdleState(Enemy owner) : base(owner) { }

    public override void Enter() => Debug.Log("Player started Moving");

    public override void Update()
    {
        // Play idle anim.

        if (!Input.GetKey(KeyCode.W))
            owner.StateMachineGeneric.ChangeState(EnemyStates.Move);
    }

    public override void Exit() => Debug.Log("Enemy stopped Moving");
}