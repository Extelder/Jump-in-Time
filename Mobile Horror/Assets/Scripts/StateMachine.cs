using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
   public State CurrentState { get; set; }

   public StateMachine(State currentState)
   {
       Initialize(currentState);
   }

   public virtual void ChangeState(State state)
   {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
   }

   public virtual void Initialize(State state)
   {
        CurrentState = state;
        CurrentState.Enter();
   }
}
