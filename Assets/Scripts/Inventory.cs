using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Больше одного предмета в инвентаре!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallBack;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {   
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Больше нет свободных ячеек!");
                return false;
            }

            items.Add(item);

            if(onItemChangeCallBack != null)
            {
                onItemChangeCallBack.Invoke();
            }            
        } 
        
        return true;       
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        } 
    }
}
