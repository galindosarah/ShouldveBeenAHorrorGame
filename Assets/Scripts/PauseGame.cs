// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script allows the game to be paused using the 'P' key and shows a menu.

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
        Time.timeScale = 0f;

        GameStateManager.Instance.SetState(GameState.Paused);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        var controller = FindFirstObjectByType<DigitalWorlds.RigidbodyFPSController>();
        controller.ResetMovement();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        Time.timeScale = 1f;

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
        Time.timeScale = 1f;
        GameStateManager.Instance.SetState(GameState.Gameplay);
        GemUIManager.Instance.ResetGemCount();
        SceneManager.LoadScene(0);
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
