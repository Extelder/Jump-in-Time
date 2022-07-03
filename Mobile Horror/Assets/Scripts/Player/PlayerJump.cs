using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private float _force;

    private void Start() => _rigidBody = GetComponent<Rigidbody>();

    public void Jump()
    {
        _rigidBody.AddForce(Vector3.up * _force);
    }
}
