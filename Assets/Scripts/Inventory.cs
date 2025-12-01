using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting.ReorderableList;

public class Inventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    GameManager manager;
    private Item sortTemp1 = null;
    Transform worldItemsTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find game manager
        manager = FindAnyObjectByType<GameManager>();

        //Find World Items transform
        Transform worldItemsTransform = GameObject.Find("InventoryItems").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (manager.state)
        {
            case GameState.GAMEPLAY:
                {
                    break;
                }
            case GameState.PAUSE:
                {
                    break;
                }
        }
        
    }

    public void AddItem(Item itemName)
    {
        items.Add(itemName);
        InventorySort();
    }


    public void RemoveItem(Item item)
    {
            //Get properties of new instance of object
            //Vector3s
            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            //Quartenions
            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 100);

            //instantiate new copy of the item
            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            //resort inventory
            InventorySort();

            //remove existing item
            items.Remove(item);
            Destroy(item.gameObject);
    }

    //removing item from first slot in inventory
    public void RemoveFirstItem()
    {
        if (manager.state == GameState.GAMEPLAY && items.Count > 0)
        {
            Item item = items[0];
            RemoveItem(item);
        }
    }

    //removing specific item from inventory
    public void RemoveSpecificItem(int i)
    {
        if(i < items.Count)
        {
            RemoveItem(items[i]);
        }
    }

    //sorting inventory (bubble sort)
    private void InventorySort()
    {
        bool itemsSorted = false;

        while (!itemsSorted)
        {
            itemsSorted = true;
            for (int i = 0; i < items.Count - 1; i++)
            {
                if (String.Compare(items[i].ItemName, items[i + 1].ItemName) > 0)
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

    //when player collides with item, add that item to inventory
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collisionItem = hit.gameObject.GetComponent<Item>();

        if (collisionItem != null)
        {

            Debug.Log("Collided with collectible: " + collisionItem.name);
            //Disable collected item
            collisionItem.gameObject.SetActive(false);

            //Add item collied with to inventory
            AddItem(collisionItem);

            

            switch (collisionItem.ItemType)
            {
                case ("Placeable"):
                    Debug.Log("You can place this");
                    break;
                case ("Throwable"):
                    Debug.Log("You can throw this");
                    break;
            }


        }
    }

}
