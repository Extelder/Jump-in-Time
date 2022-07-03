using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateMachine : StateMachine
{
    public RatStateMachine(State currentState) : base(currentState) { }

    public override void ChangeState(State state)
    {
        if(state != null) CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
