using UnityEngine;

public class EnemyMoveState : State<Enemy>
{
    public EnemyMoveState(Enemy owner) : base(owner) { }

    public override void Enter()
    {
        owner.OnEnterMoveState();
        Debug.Log("Player started Moving");
    }

    public override void Update()
    {
        owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            owner.StateMachineGeneric.ChangeState(EnemyStates.Idle);
    }

    public override void Exit() => Debug.Log("Enemy stopped Moving");
}