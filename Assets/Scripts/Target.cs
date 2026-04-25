// Final
// DIG 3878
// Sarah Galindo
// Annette Gonzalez
// This script allows the fireball to destroy the targets.

using UnityEngine;

public class Target : MonoBehaviour
{
    public PuzzleManager puzzleManager;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            puzzleManager.TargetDestroyed();
            Destroy(gameObject);
        }
    }
}
