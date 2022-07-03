using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _range;
    [SerializeField] private PlayerItem _playerItem;

    private void OnEnable()
    {
        _playerInputs.InteractButtonDowned += Interact;
    }

    private void OnDisable()
    {
        _playerInputs.InteractButtonDowned -= Interact;
    }

    public void Interact()
    {
        IInteractable interactable = RaycastInteraction.ThrowRaycast<IInteractable>(_camera, _camera.forward, _range);
        if (interactable != null)
        {
            if(_playerItem.Current.Value != null)
            {
                interactable.Interact(_playerItem.Current.Value);
            }
     
        }
    }
}
