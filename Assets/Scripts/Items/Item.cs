using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Name item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        // Использование предмета
        // разные действия

        Debug.Log("Используем " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
