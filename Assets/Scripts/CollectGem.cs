// Final
// DIG 3878
// Sarah Galindo
// Celine Hui
// This script allows the player to collect the gem and make a noise when collected.

using UnityEngine;

public class CollectGem : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            if (GemUIManager.Instance != null)
            {
                GemUIManager.Instance.AddGem();
            }

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
