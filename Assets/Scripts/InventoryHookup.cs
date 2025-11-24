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

    void InventoryUpdate()
    {
        Debug.Log("Updating Inventory");

        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            inventoryButtons[i].SetActive(false);
        }

        for (int i = 0; i < activeInventory.items.Count; i++)
        {
            if(i <  inventoryButtons.Count)
            {
                InventoryUIButton button = inventoryButtons[i].GetComponent<InventoryUIButton>();
                Item item = activeInventory.items[i];

                inventoryButtons[i].SetActive(true);
                button.SetButton(item);
            }
        }
    }

    public void OnInventoryUIButton(int i)
    {
        activeInventory.RemoveSpecificItem(i);
        InventoryUpdate();
    }
}
