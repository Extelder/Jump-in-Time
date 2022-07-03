using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;


public class RatDetectiveThiefPlaceState : RatState
{
    private string _roomName;

    public static event Action<string> OnDetectiveRoom;

    public RatDetectiveThiefPlaceState(NavMeshAgent agent, string roomName) : base(agent)
    {
        _roomName = roomName;
    }

    public override void Enter()
    {
        OnDetectiveRoom.Invoke(_roomName);
    }

    public override void Exit()
    {
        
    }
}