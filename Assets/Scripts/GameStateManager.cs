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

    public void LoadMainMenu()
    {   
        Time.timeScale = 1f;

        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.SetState(GameState.Gameplay);
        }

        if (GemUIManager.Instance != null)
        {
            GemUIManager.Instance.ResetGemCount();
        }

        SceneManager.LoadScene(0);
    }
}
