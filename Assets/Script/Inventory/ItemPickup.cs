using System;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        Destroy(gameObject);
        InventoryManager.instance.AddItem(item);
    }

    private void OnMouseDown()
    {
        Pickup();
        
    }
}
