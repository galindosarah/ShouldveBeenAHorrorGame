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
