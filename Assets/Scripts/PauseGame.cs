using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject instructionsMenu;
    //public static bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        resumeCursorState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameStateManager.Instance.IsPaused())
                Resume();
            else if (GameStateManager.Instance.IsGameplay())
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);

        GameStateManager.Instance.SetState(GameState.Paused);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(false);

        GameStateManager.Instance.SetState(GameState.Gameplay);

        resumeCursorState();
    }

    void resumeCursorState()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMainMenu()
    {
        GameStateManager.Instance.SetState(GameState.Gameplay);
        SceneManager.LoadScene("TitleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        pauseMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }
}
