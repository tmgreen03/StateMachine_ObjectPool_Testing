using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private Transform _playerTransform;

    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();        
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Leaving Chase State");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        Move();

        if (enemy.IsWithinAttackRange)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Move()
    {
        Vector3 moveDirection = (_playerTransform.position - enemy.transform.position).normalized;
        enemy.Move(moveDirection * enemy.MoveSpeed);
    }
}
