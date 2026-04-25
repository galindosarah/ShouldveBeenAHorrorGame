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
