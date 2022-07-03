using System;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    public float TimeOnPoint;
    public string RoomName;

    public event Action<string> OnDestinationPointCompleate;

    [SerializeField] private string _animationName;

    public void DistinationCompleate()
    {
        OnDestinationPointCompleate?.Invoke(_animationName);
    }
}
