using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHookup : MonoBehaviour
{
    public Inventory activeInventory;
    public List<GameObject> inventoryButtons = new List<GameObject>();

    private void OnEnable()
    {
        InventoryUpdate();
    }

    //Update inventory screen when it is changed
    void InventoryUpdate()
    {
        Debug.Log("Updating Inventory");

        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            //deactivate all buttons
            inventoryButtons[i].SetActive(false);
        }

        for (int i = 0; i < activeInventory.items.Count; i++)
        {
            if(i <  inventoryButtons.Count)
            {
                //activate buttons if an item is in the associated inventory slot
                InventoryUIButton button = inventoryButtons[i].GetComponent<InventoryUIButton>();
                Item item = activeInventory.items[i];

                inventoryButtons[i].SetActive(true);
                button.SetButton(item);
            }
        }
    }

    //remove item from inventory when associated button is pressed
    public void OnInventoryUIButton(int i)
    {
        activeInventory.RemoveSpecificItem(i);
        InventoryUpdate();
    }
}
