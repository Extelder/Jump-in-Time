using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private Product[] _products;

    public void Interact(InventoryItem item)
    {
        foreach (Product product in _products)
        {
            if (product.Cost == item)
            {
                product.Buy();
            }
        }
    }
}
