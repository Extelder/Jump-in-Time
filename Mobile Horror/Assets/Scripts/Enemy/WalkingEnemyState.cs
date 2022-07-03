using System;
using UnityEngine.AI;
using UnityEngine;


public class IdleEnemyState : EnemyState
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private string _animationName;

    public IdleEnemyState(NavMeshAgent navMeshAgent)
    {
        _agent = navMeshAgent;
    }

    public override void Enter()
    {
        _agent.isStopped = true;
    }

    public override void Exit()
    {
        _agent.isStopped = false;
    }
}

