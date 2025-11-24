using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{

    [SerializeField] GameManager manager;

    private void OnPause(InputValue value)
    {
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
        if (value.isPressed)
        {
            Debug.Log("Removed Item");
            GetComponent<Inventory>().RemoveFirstItem();
        }
    }

}
