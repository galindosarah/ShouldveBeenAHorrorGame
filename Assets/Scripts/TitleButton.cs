using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour, IInteractable
{
    public string titleSceneName = "TitleScene";

    public void Interact(Transform player, Transform inspectPoint)
    {
        Debug.Log("Button pressed!");
        SceneManager.LoadScene(titleSceneName);
    }

    public void StopInteract()
    {
        // Not needed
    }

    public bool RequiresInspection()
    {
        return false;
    }
}
