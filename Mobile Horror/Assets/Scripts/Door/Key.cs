using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InventoryItem
{
    public void DoorOpened() => Destroy(gameObject);
}
