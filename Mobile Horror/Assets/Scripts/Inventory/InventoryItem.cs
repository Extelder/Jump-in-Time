using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Item _prefab;

    public Item Prefab { 
        get
        {
           return _prefab;
        }
        set
        {
            _prefab = value;
        } }

    public void Disactivate()
    {
        PlayerItem.CurrentItemDisActivated.Execute();
        gameObject.SetActive(false);
    }
}
