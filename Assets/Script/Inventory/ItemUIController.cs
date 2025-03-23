using TMPro;
using UnityEngine;

public class ItemUIController : MonoBehaviour
{
    public Item thisItem;
 
    public void SetItem(Item item)
    {
        this.thisItem = item;
    }

    public void RemoveItem()
    {
        InventoryManager.instance.RemoveItem(thisItem,gameObject);
        
    }

    public void ShowItem()
    {
        InventoryManager.instance.ShowItemInfor(thisItem);
    }

    public void testAni()
    {
        
    }
    public void UseItem()
    {
        switch (thisItem.itemType)
        {
            
            case ItemType.HoiHP:
            {
                Player playerHealth = FindAnyObjectByType<Player>();

                if (playerHealth != null)
                {
                    playerHealth.TruHp(thisItem.value);
                }
                break;
            }
        }
        RemoveItem();
    }
}
