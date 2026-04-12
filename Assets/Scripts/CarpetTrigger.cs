using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            puzzleManager.playerOnCarpet = true;
        }
    }
}
