using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    public void Interact()
    {
        if (puzzleManager.playerOnCarpet)
        {
            puzzleManager.StartPuzzle();
        }
    }
}
