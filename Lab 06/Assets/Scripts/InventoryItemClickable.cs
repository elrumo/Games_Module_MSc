using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemClickable : MonoBehaviour
{    
    public IInventoryItem item;

    public Inventory inventory;


    public void OnItemClicked()
    {
        if (item != null)
        {
            Debug.Log("Using: " + item.itemName);
            inventory.useItem(item);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(item);
    }
}
