// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script allows the player to navigate to the main menu.

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToMainMenu()
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
