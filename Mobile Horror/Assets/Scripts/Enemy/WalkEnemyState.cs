using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkEnemyState : EnemyState
{
    public DestinationPoint CurrentDestinationPoint { get; private set; }

    private NavMeshAgent _agent;
    private DestinationPoint[] _points;
    private int i = 0;

    public WalkEnemyState(NavMeshAgent agent, DestinationPoint[] _targetPoints)
    {
        _agent = agent;
        _points = _targetPoints;
    }

    public override void Enter()
    {
        CurrentDestinationPoint = _points[0];
        RoutinesManager.Instance.StartCoroutine(Walk());
    }

    public override void Exit()
    {
        RoutinesManager.Instance.StopCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            CurrentDestinationPoint = _points[i];
            _agent.SetDestination(_points[i].transform.position);

            yield return new WaitForSeconds(0.03f);
            yield return new WaitUntil(() => _agent.remainingDistance == 0f);

            _points[i].DistinationCompleate();

            yield return new WaitForSeconds(_points[i].TimeOnPoint);   

            i++;
            if(i == _points.Length) i = 0;
        }
    }
}

