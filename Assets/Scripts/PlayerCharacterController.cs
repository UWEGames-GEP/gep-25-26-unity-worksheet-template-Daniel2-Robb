using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{

    [SerializeField] GameManager manager;

    private void OnPause(InputValue value)
    {
        manager.Pause();
        LockCameraPosition = !LockCameraPosition;
    }

    private void OnInventoryOpenClose(InputValue value)
    {
        manager.Inventory();
        LockCameraPosition = !LockCameraPosition;
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
