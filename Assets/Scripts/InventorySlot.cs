using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;

        icon.sprite = _item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
