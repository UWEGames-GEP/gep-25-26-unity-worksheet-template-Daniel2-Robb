using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    GAMEPLAY, INVENTORY, PAUSE
};

public class GameManager : MonoBehaviour
{
    public GameState state;
    private bool gameStateChanged = false;
    [SerializeField] GameObject inventory_menu;
    [SerializeField] GameObject pause_menu;
    [SerializeField]PlayerCharacterController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }
    
    //Late Update is called once per frame after Update
    private void LateUpdate()
    {
        if (gameStateChanged)
        {
            gameStateChanged = false;

            switch (state)
            {
                case GameState.GAMEPLAY:

                    //set time scale so that physics interactions occur, deactivate any menus, lock cursor
                    Time.timeScale = 1.0f;
                    inventory_menu.SetActive(false);
                    pause_menu.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;

                    break;

                case GameState.INVENTORY:

                    //set time scale so that physics interactions do not occur, activate Inventory menu, unlock cursor
                    Time.timeScale = 0.0f;
                    inventory_menu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;

                    break;  

                case GameState.PAUSE:

                    //set time scale so that physics interactions do not occur, activate Pause menu, unlock cursor
                    Time.timeScale = 0.0f;
                    pause_menu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    break;
            }
        }
    }

    public void Pause()
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                state = GameState.PAUSE;
                gameStateChanged = true;
                break;

            case GameState.PAUSE:
                state = GameState.GAMEPLAY;
                gameStateChanged = true;
                break;


        }
    }

    public void Inventory()
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                state= GameState.INVENTORY;
                gameStateChanged= true;
                break;

            case GameState.INVENTORY:
                state= GameState.GAMEPLAY;
                gameStateChanged = true;
                break;
        }
    }
}
