using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public DestinationPoint CurrentDestinationPoint { get; private set; }

    private NavMeshAgent _agent;
    private StateMachine _stateMachine;
    private WalkEnemyState _walkEnemyState;
    
    [SerializeField] private DestinationPoint[] _walkPoints;
    [SerializeField] private Transform _player;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _walkEnemyState = new WalkEnemyState(_agent, _walkPoints);
        _stateMachine = new EnemyStateMachine(_walkEnemyState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _stateMachine.ChangeState(new HuntEnemyState(_agent, _player, transform));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _stateMachine.ChangeState(_walkEnemyState);
        }
    }

    public string GetCurrentDestinationRoomName()
    {
        return _walkEnemyState.CurrentDestinationPoint.RoomName;
    }

}
