using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{

    public List<string> items = new List<string>();
    public GameManager manager;
    private string sortTemp1 = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (manager.state)
        {
            case GameState.GAMEPLAY:
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        AddItem("placeholder");
                    }
                    else if (Input.GetKeyDown(KeyCode.O))
                    {
                        RemoveItem("placeholder");
                    }
                    break;
                }
            case GameState.PAUSE:
                {
                    break;
                }
        }
        
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        InventorySort();

    }

    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
        InventorySort();
    }

    private void InventorySort()
    {
        bool itemsSorted = false;

        while (!itemsSorted)
        {
            itemsSorted = true;
            for (int i = 0; i < items.Count - 1; i++)
            {
                if (String.Compare(items[i], items[i + 1]) > 0)
                {
                    sortTemp1 = items[i];
                    items[i] = items[i + 1];
                    items[i + 1] = sortTemp1;
                    itemsSorted = false;
                    sortTemp1 = null;
                }
            }
            Debug.Log("Inventory sorted");
        }
    }
}
