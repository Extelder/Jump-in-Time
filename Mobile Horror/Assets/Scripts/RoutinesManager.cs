using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RoutinesManager : MonoBehaviour
{
    public static RoutinesManager Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void StartRoutine(Coroutine coroutine)
    {
        StartCoroutine(nameof(coroutine));
    }
    public void StopRoutine(Coroutine coroutine)
    {
        StopCoroutine(nameof(coroutine));
    }
}
