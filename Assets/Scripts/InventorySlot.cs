using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;

        icon.sprite = _item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void RemoveButton()
    {
        Inventory.instance.Remove(_item);
    }

    public void UseItem()
    {
        if(_item != null)
        {
            _item.Use();
        }
    }
}
