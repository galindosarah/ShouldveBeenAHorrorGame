// Final
// DIG 3878
// Sarah Galindo
// This script allows the player to interact with the button that starts the first puzzle.

using UnityEngine;

public class PuzzleButton : MonoBehaviour, IInteractable
{
    public PuzzleManager puzzleManager;
    private bool used = false;

    public void Interact(Transform player, Transform inspectPoint)
    {
        if (used) return;

        used = true;
        puzzleManager.StartPuzzle();
    }

    public void StopInteract()
    {
    }

    public bool RequiresInspection()
    {
        return false;
    }
}