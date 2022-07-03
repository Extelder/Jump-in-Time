using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class HuntEnemyState : EnemyState
{
    private CompositeDisposable _disposables = new CompositeDisposable();
    private NavMeshAgent _agent;
    private Transform _target;
    private Transform _transform;

    public HuntEnemyState(NavMeshAgent agent, Transform target, Transform transform)
    {
        _agent = agent;
        _target = target;  
        _transform = transform;
    }

    public override void Enter()
    {
        _agent.updateRotation = false;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _transform.LookAt(_target.position, Vector3.up);
            _agent.SetDestination(_target.position);
        }).AddTo(_disposables);
    }

    public override void Exit()
    {
        _agent.updateRotation = true;
        _disposables.Clear();
    }
}
