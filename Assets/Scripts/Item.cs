using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "Name item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
