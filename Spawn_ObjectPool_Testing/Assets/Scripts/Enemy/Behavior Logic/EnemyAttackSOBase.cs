using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSOBase : ScriptableObject
{
    protected Enemy _enemy;
    protected Transform _transform;
    protected GameObject _gameObject;

    protected Transform _playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this._gameObject = gameObject;
        _transform = gameObject.transform;
        this._enemy = enemy;

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { ResetValues(); }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType) { }
    public virtual void ResetValues() { }
}
