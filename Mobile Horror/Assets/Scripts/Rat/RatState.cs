using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.AI;

public abstract class RatState : State
{
    public NavMeshAgent Agent { get; private set; }

    public RatState(NavMeshAgent agent)
    {
        Agent = agent;
    }

    public abstract override void Enter();

    public abstract override void Exit();
}
