using UnityEngine;

public class itemPickUp : Interactable
{
    public Item _item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Предмет поднят: " + _item.name);

        bool wasPickedUp = Inventory.instance.Add(_item);  
        if(wasPickedUp)
        {
            Destroy(gameObject);
        }               
    }
}
