using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    GAMEPLAY, PAUSE
};

public class GameManager : MonoBehaviour
{
    public GameState state;
    private bool gameStateChanged = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        
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

                    Time.timeScale = 1.0f;

                    break;

                case GameState.PAUSE:

                    Time.timeScale = 0.0f;

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
}
