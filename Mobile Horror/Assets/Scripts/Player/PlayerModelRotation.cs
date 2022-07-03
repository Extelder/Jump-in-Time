using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerModelRotation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable() => Observable.EveryUpdate().Subscribe(_ =>
    {
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, _target.eulerAngles.y, transform.eulerAngles.z);}).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}
