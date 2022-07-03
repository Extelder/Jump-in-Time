using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool _close = true;
    
    [SerializeField] private bool _lock;
    [SerializeField] private Key _keyToOpen;

    public void Interact(InventoryItem item)
    {
        if(item != null)
        {
            if (item == _keyToOpen)
            {
                Debug.Log("AAAAA");
                Key key = item as Key;
                _lock = false;
                key.DoorOpened();
                return;
            }
        }
       
        Action();
    }

    private void Action()
    {
        if (!_lock)
        {
            if (_close)
            {
                Open();           
                return;
            }
            Close();
        }
    } 

    private void Open()
    {
        Debug.Log("Opened");
        _close = false;
    }
    private void Close()
    {
        Debug.Log("Closeed");
        _close = true;
    }
}
