using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Pickup, IInteractable
{
    [Header("Inventory Item in scene")]
    public InventoryItem ReferenceInScene;

    public static event Action<InventoryItem> ItemPickuped;

    public override void PickUp()
    {
        ItemPickuped.Invoke(ReferenceInScene);
        Destroy(gameObject);
    }

    public void Interact(InventoryItem item)
    {
        PickUp();
    }
}
