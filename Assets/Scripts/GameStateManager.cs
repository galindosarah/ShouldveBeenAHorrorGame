// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script uses a singleton pattern to manage the game state across different scenes.

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;


    public GameState CurrentState { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        CurrentState = GameState.Gameplay;
    }

    public void SetState(GameState state)
    {
        CurrentState = state;
    }

    public bool IsGameplay()
    {
        return CurrentState == GameState.Gameplay;
    }

    public bool IsPaused()
    {
        return CurrentState == GameState.Paused;
    }

    public bool IsInspecting()
    {
        return CurrentState == GameState.Inspecting;
    }
}
