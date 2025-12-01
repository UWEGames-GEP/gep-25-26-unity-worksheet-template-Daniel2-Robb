using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{

    [SerializeField] GameManager manager;

    private void OnPause(InputValue value)
    {
        //Pause/unpause game, locking and unlocking camera as needed
        manager.Pause();
        switch (manager.state)
        {
            case GameState.PAUSE:
                LockCameraPosition = true;
                break;

            case GameState.GAMEPLAY:
                LockCameraPosition = false;
                break;
        }
    }

    private void OnInventoryOpenClose(InputValue value)
    {
        //open/close inventory, locking and unlocking camera as needed
        manager.Inventory();
        switch (manager.state)
        {
            case GameState.INVENTORY:
                LockCameraPosition = true;
                break;

            case GameState.GAMEPLAY:
                LockCameraPosition = false;
                break;
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        //remove first item in inventory array
        if (value.isPressed)
        {
            Debug.Log("Removed Item");
            GetComponent<Inventory>().RemoveFirstItem();
        }
    }

}
