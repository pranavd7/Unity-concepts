using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

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
    [SerializeField] protected EnemyStatsSO enemyStats;
    protected int damage;
    
    // Different types of events
    [SerializeField] private GameEventSO onEnemyDeathEventSO;
    [SerializeField] private MeshRenderer meshRenderer;
    
    public static EnemyDefeated EnemyDefeated;
    public static event EnemyDefeated OnEnemyDefeated;
    public static event Action<Enemy> OnEnemyDied;

    private int currentHealth;
    private int armour = 10;
    
    // private StateMachine statemachine;
    // private EnemyPatrolState patrolState;
    // private EnemyAttackState attackState;
    // private EnemyCelebrateState celebrateState;
    
    public float speed;
    private StateMachine<Enemy> stateMachineGeneric;
    
    // For Hit flash effect
    private Color originalColor;
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    // Properties
    
    // public StateMachine StateMachine => statemachine;
    // public EnemyPatrolState PatrolState => patrolState;
    // public EnemyAttackState AttackState => attackState;
    // public EnemyCelebrateState CelebrateState => celebrateState;
    public StateMachine<Enemy>  StateMachineGeneric => stateMachineGeneric;

    private void Awake()
    {
        currentHealth = enemyStats.maxHealth;
        Debug.Log($"Health = {currentHealth}");
        
        // Init statemachine.
        // patrolState = new EnemyPatrolState(this);
        // attackState = new EnemyAttackState(this);
        // celebrateState = new EnemyCelebrateState(this);
        // statemachine = new StateMachine(PatrolState);
        
        // Init generic state machine.
        stateMachineGeneric = new StateMachine<Enemy>();
        stateMachineGeneric.RegisterState(EnemyStates.Move, new EnemyMoveState(this));
        stateMachineGeneric.RegisterState(EnemyStates.Idle, new EnemyIdleState(this));
        stateMachineGeneric.RegisterState(EnemyStates.Attacking, new EnemyChaseState(this));
        stateMachineGeneric.ChangeState(EnemyStates.Idle);
        
        originalColor = meshRenderer.material.GetColor("_Color");
    }

    private void Update()
    {
        // statemachine.Update();
        stateMachineGeneric.Update();
    }

    public void TakeDamage(int damage)
    {
        int newDamage = (int)(damage * (1 - armour / 100f));
        currentHealth -= newDamage;
        Debug.Log($"Taking damage: {newDamage}");
        
        // Tween to flash color, then back to original
        meshRenderer.material.DOColor(flashColor, flashDuration)
            .OnComplete(() => meshRenderer.material.DOColor(originalColor, flashDuration));
        
        transform.DOShakePosition(1f, 0.5f);
        
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
        // Debug.Log($"Enemy died");
        // EnemyDefeated?.Invoke(enemyStats.score);
        OnEnemyDefeated?.Invoke(enemyStats.score);
        // OnEnemyDied?.Invoke(this);
        onEnemyDeathEventSO.Raise();
        
        // GameManager.Instance.AddScore(10);
        // TestManager.Instance.gameObject.SetActive(false);
        // TestManager2.Instance.CalculateMath(transform.position, new Vector3(5, 21, 2));
        
        Destroy(gameObject);
    }

    public void OnEnterMoveState()
    {
        // move forward
        // take damage
    }
}
