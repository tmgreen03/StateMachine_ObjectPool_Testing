using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Ranged", menuName = "Enemy Logic/ Attack Logic/ Ranged")]
public class EnemyAttackRanged : EnemyAttackSOBase
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _fireRate = 1f;

    private float _timer;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        Debug.Log("Ranged Attack State");

        _timer = _fireRate;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        Debug.Log("Leaving Ranged Attack State");
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        _enemy.Move(Vector3.zero);

        //RANGED ATTACK
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Fire();
            _timer = _fireRate;
        }

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

    private void Fire()
    {
        if (_playerTransform != null)
        {
            // Calculate the direction to the player.
            Vector3 directionToPlayer = _playerTransform.transform.position - _enemy.transform.position;
            directionToPlayer.Normalize();

            // Instantiate a new bullet.
            GameObject bullet = Instantiate(_bulletPrefab, _enemy.transform.position, Quaternion.identity);

            // Get the Rigidbody component of the bullet.
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Apply a force to the bullet in the direction of the player.
            bulletRigidbody.velocity = directionToPlayer * _bulletSpeed; // Adjust bulletSpeed as needed.
        }
    }

}
