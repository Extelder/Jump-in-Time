using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Product : MonoBehaviour
{
    [field: SerializeField] public InventoryItem Cost { get; private set; }
    public UnityEvent Bought;

    public virtual void Buy()
    {
        Debug.Log("buyed" + Cost);
        Bought.Invoke();
        Cost.Disactivate();
    }
}
