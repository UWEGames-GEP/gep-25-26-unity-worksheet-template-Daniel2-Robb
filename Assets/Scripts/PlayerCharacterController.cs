using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{

    [SerializeField] GameManager manager;

    private void OnPause(InputValue value)
    {
        manager.Pause();
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
