using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Ranged", menuName = "Enemy Logic/ Attack Logic/ Ranged")]
public class EnemyAttackRanged : EnemyAttackSOBase
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _timeBetweenShots = 2f;
    [SerializeField] private float _timeTillExit = 3f;
    [SerializeField] private float _distanceToCountExit = 3f;
    [SerializeField] private float _bulletSpeed = 10f;

    private float _timer;
    private float _exitTimer;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _enemy.Move(Vector3.zero);

        if (_timer > _timeBetweenShots)
        {
            _timer = 0f;

            Vector3 dir = (_playerTransform.position - _enemy.transform.position).normalized;

            Rigidbody bullet = GameObject.Instantiate(_bulletPrefab, _enemy.transform.position, Quaternion.identity);
            bullet.velocity = dir * _bulletSpeed;
        }

        if (Vector3.Distance(_playerTransform.position, _enemy.transform.position) > _distanceToCountExit)
        {
            _exitTimer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                _enemy.StateMachine.ChangeState(_enemy.ChaseState);
            }
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
