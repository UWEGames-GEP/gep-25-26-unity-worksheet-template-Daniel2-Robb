using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameManager manager;
    PlayerCharacterController player;

    public void Start()
    {
        //find game manager
        manager = FindAnyObjectByType<GameManager>();

        //find player object
        player = FindAnyObjectByType<PlayerCharacterController>();
    }

    private void OnEnable()
    {
        Debug.Log("Paused");
    }

    public void OnPauseMenuButton(string button)
    {
        if (button == "resume")
        {
            //return to GAMEPLAY state when resumed, unlock player camera
            Debug.Log("Resuming");
            manager.Pause();
            player.LockCameraPosition = false;
        }
        else if (button == "quit")
        {
            //Exit play mode in editor / quit application
            Debug.Log("Quitting");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
