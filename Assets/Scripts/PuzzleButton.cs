using UnityEngine;

public class PuzzleButton : MonoBehaviour, IInteractable
{
    public PuzzleManager puzzleManager;
    private bool activated = false;

    public void Interact(Transform player, Transform inspectPoint)
    {
        if (activated) return;

        puzzleManager.StartPuzzle();
        activated = true;
    }

    public void StopInteract()
    {
        //Not needed
    }

    public bool RequiresInspection()
    {
        return false;
    }
}
