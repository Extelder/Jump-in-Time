using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class RatAggresiveState : RatState
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    private Transform _target;

    public RatAggresiveState(NavMeshAgent agent, Transform target) : base(agent)
    {
        _target = target;
    }

    public override void Enter()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            Agent.SetDestination(_target.position);
        }).AddTo(_disposable);
    }

    public override void Exit()
    {
        _disposable.Clear();
    }
}
