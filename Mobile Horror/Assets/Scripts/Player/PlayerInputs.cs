using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private KeyCode _interactKeyCode;
    private CompositeDisposable _disposable = new CompositeDisposable();

    public event Action InteractButtonDowned;

    private void Start() => Observable.EveryUpdate().Subscribe(_ =>
    {
        if (Input.GetKeyDown(_interactKeyCode)) InteractButtonDowned?.Invoke();
    }).AddTo(_disposable);
}