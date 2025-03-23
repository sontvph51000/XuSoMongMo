using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance{get; private set;}
    public List<Item> itemList = new List<Item>();
    
    public Transform itemParent;
    public GameObject itemPrefab;

    public GameObject itemInfor;
    private void Awake()
    {
        if (instance != null || instance != this)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void ShowItemInfor(Item item)
    {
        itemInfor.SetActive(true);
        var iName = itemInfor.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        var iInfor = itemInfor.transform.Find("TextInfor").GetComponent<TextMeshProUGUI>();

        iName.text = item.name;
        iInfor.text = item.itemInfor;


    }

    
    public void AddItem(Item item)
    {
        
        Item existingItem = itemList.FirstOrDefault(i => i.id == item.id);
        if (existingItem != null)
        {
            existingItem.itemQuantity++;
        }
        else
        {
            item.itemQuantity = 1;
            itemList.Add(item);
        }
        DisplayInventory();
    }

    public void RemoveItem(Item item, GameObject g)
    {
        Item existingItem = itemList.FirstOrDefault(i => i.name == item.name);
        if (existingItem != null)
        {
            existingItem.itemQuantity--; // Giảm số lượng
            if (existingItem.itemQuantity <= 0)
            {
                itemList.Remove(existingItem);
                Destroy(g.gameObject);// Nếu số lượng về 0 thì xóa khỏi danh sách
            }

            DisplayInventory();
        }
    }
    public void DisplayInventory()
    {
        
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Item item in itemList)
        {
            
            
            GameObject obj = Instantiate(itemPrefab, itemParent);
            
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();
            var itemQuantity = obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
            
            itemName.text = item.name;
            itemImage.sprite = item.sprite;
            itemQuantity.text = item.itemQuantity.ToString();
            
            obj.GetComponent<ItemUIController>().SetItem(item);
        }
    }
}
