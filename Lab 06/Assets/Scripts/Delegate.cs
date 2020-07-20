using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delegate : MonoBehaviour
{

    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryItemAdded;
    }

    private void InventoryItemAdded(object sender, InventoryEventArgs e)
    {
        Transform panel = transform.Find("InventoryHud");

        foreach(Transform slot in panel)
        {
            Image image = slot.GetComponent<Image>();
            foreach(Transform buttonS in slot){

                InventoryItemClickable button = buttonS.GetComponent<InventoryItemClickable>();

                if (!image.enabled)
                {
                    image.enabled = true;
                    image.sprite = e.item.itemImage;
                    button.item = e.item;

                    break;
                }
            }
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
