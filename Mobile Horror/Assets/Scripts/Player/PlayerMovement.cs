using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed;

    private void Update()
    {
        _rigidBody.velocity = (transform.forward * _joystick.Vertical * _speed) + (transform.right * _joystick.Horizontal * _speed) + (transform.up * _rigidBody.velocity.y);
    }
}
