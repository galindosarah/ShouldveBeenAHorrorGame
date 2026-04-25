// Final
// DIG 3878
// Annette Gonzalez
// Sarah Galindo
// This script allows the carpet to raise when the player steps on it.

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