using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilButton : MonoBehaviour, IInteractable
{
    private bool used = false;

    public void Interact(Transform player, Transform inspectPoint)
    {
        if (used) return;

        used = true;
        GameStateManager.Instance.SetState(GameState.Gameplay);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void StopInteract()
    {
    }

    public bool RequiresInspection()
    {
        return false;
    }
}