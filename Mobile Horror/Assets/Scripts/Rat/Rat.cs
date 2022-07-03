using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rat : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _player;
    private RatStateMachine _stateMachine;
    private NavMeshAgent _agent;

    public void SetAggressiveState()
    {
        _stateMachine.ChangeState(new RatAggresiveState(_agent, _player));
    }

    public void SetDetectiveThiefPlaceState()
    {
        _stateMachine.ChangeState(new RatDetectiveThiefPlaceState(_agent, _enemy.GetCurrentDestinationRoomName()));
    }

    public void SetPlayerHelpState()
    {
        _stateMachine.ChangeState(new RatPlayerHelpState(_agent));
    }
}
