using System;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public int maxHealth;
    public int enemyId;
}

// Declare a delegate type.
public delegate void EnemyDefeated(int score);

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] EnemyStatsSO enemyStats;

    // Different types of events
    [SerializeField] private GameEventSO gameEventSO;
    public static EnemyDefeated EnemyDefeated;
    public static event EnemyDefeated OnEnemyDefeated;
    public static event Action<Enemy> OnEnemyDied;

    private int currentHealth;
    private int armour = 10;
    
    private StateMachine statemachine;
    private EnemyPatrolState patrolState;
    private EnemyAttackState attackState;
    private EnemyCelebrateState celebrateState;
    
    public float speed;
    private StateMachine<Enemy> stateMachineGeneric;
    
    // Properties
    
    public StateMachine StateMachine => statemachine;
    public EnemyPatrolState PatrolState => patrolState;
    public EnemyAttackState AttackState => attackState;
    public EnemyCelebrateState CelebrateState => celebrateState;
    public StateMachine<Enemy>  StateMachineGeneric => stateMachineGeneric;

    private void Awake()
    {
        currentHealth = enemyStats.maxHealth;
        Debug.Log($"Health = {currentHealth}");
        
        // Init statemachine.
        patrolState = new EnemyPatrolState(this);
        attackState = new EnemyAttackState();
        celebrateState = new EnemyCelebrateState(this);
        statemachine = new StateMachine(PatrolState);
        
        // Init generic state machine.
        stateMachineGeneric = new StateMachine<Enemy>();
        stateMachineGeneric.RegisterState(EnemyStates.Move, new EnemyMoveState(this));
        stateMachineGeneric.RegisterState(EnemyStates.Idle, new EnemyIdleState(this));
    }

    private void Update()
    {
        statemachine.Update();
        stateMachineGeneric.Update();
    }

    public void TakeDamage(int damage)
    {
        int newDamage = (int)(damage * (1 - armour / 100f));
        currentHealth -= newDamage;
        Debug.Log($"Taking damage: {newDamage}");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Stagger()
    {
    }
    
    public void Die()
    {
        Debug.Log($"Enemy died");
        OnEnemyDefeated?.Invoke(enemyStats.score);
        OnEnemyDied?.Invoke(this);
        gameEventSO.Raise();
        
        Destroy(gameObject);
    }
}
