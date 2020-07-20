using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    
    List<IInventoryItem> items = new List<IInventoryItem>();
    

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemUsed;

    public void addItem(IInventoryItem item)
    {
        items.Add(item);
        item.onPickup();

        // broadcast event to the hud
        if (ItemAdded != null)
        {
            ItemAdded.Invoke(this, new InventoryEventArgs(item));
        }

    }

    public void useItem(IInventoryItem item)
    {
        // ItemUsed = item; 
        Debug.Log(item);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
