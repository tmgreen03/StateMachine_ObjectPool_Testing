using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, IMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public float MoveSpeed { get; set; } = 3f;

    public float CurrentHealth { get; set; }
    public Rigidbody RB { get; set; }

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; } 
    public EnemyAttackState AttackState { get; set; }

    public bool IsWithinAttackRange { get; set; }
    public bool IsAggroed { get; set; }

    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }

    private void Awake()
    {
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody>();

        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Move(Vector3 velocity)
    {
        RB.velocity = velocity;
    }

    public void SetAttackRangeBool(bool isWithinAttackRange)
    {
        IsWithinAttackRange = isWithinAttackRange;
    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    //Assuming we will have animations for enemies they can trigger events
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType); 
    }
    public enum AnimationTriggerType
    {
        EnemyDamaged, 
        EnemyDie
    }
}
