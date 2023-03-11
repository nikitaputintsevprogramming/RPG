using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;

    Inventory _inventory;

    InventorySlot[] slots;

    void Start()
    {
        _inventory = Inventory.instance;
        _inventory.onItemChangeCallBack += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }
    
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int count = 0; count < slots.Length; count++)
        {
            if(count < _inventory.items.Count)
            {
                slots[count].AddItem(_inventory.items[count]);
            }
            else
            {
                slots[count].ClearSlot();
            }
        }
    }
}
