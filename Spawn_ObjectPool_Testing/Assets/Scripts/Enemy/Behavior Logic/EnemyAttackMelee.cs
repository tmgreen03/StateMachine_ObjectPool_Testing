using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Melee", menuName = "Enemy Logic/ Attack Logic/ Melee")]
public class EnemyAttackMelee : EnemyAttackSOBase
{
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Melee Attack State");
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        Debug.Log("Leaving Melee Attack State");
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _enemy.Move(Vector3.zero);

        if (!_enemy.IsWithinAttackRange)
        {
            _enemy.StateMachine.ChangeState(_enemy.ChaseState);
        }
    }

    public override void DoPhysicsUpdateLogic()
    {
        base.DoPhysicsUpdateLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
