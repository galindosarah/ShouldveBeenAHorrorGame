using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public Transform platformTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.SetPlayerOnCarpet(true);
            other.transform.SetParent(platformTransform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.SetPlayerOnCarpet(false);
            other.transform.SetParent(null);
        }
    }
}