using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameState CurrentState { get; private set; }

    void Awake()
    {
        Instance = this;
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
