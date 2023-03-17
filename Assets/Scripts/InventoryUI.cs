using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform ItemsParent;
    public GameObject inventoryUI;

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
        if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
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
