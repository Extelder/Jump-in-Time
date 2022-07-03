using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _range;

    public void TryPickup()
    {
        Pickup item = RaycastInteraction.ThrowRaycast<Pickup>(_camera, _camera.forward, _range);
        if(item != null)
        {
            item.PickUp();
        }
    }
}
