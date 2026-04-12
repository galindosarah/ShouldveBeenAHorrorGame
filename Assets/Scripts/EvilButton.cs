using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilButton : MonoBehaviour, IInteractable
{
    private bool used = false;

    public void Interact(Transform player, Transform inspectPoint)
    {
        if (used) return;

        used = true;
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