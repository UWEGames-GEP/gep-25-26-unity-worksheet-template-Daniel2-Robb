using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameManager manager;
    [SerializeField] PlayerCharacterController player;

    private void OnEnable()
    {
        Debug.Log("Paused");
    }

    public void OnPauseMenuButton(string button)
    {
        if (button == "resume")
        {
            Debug.Log("Resuming");
            manager.Pause();
            player.LockCameraPosition = false;
        }
        else if (button == "quit")
        {
            Debug.Log("Quitting");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
