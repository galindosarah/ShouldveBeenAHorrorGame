using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            RestartLevel(other.gameObject);

            Invoke(nameof(ResetTrap), 1f);
        }
    }

    private void RestartLevel(GameObject player)
    {
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
    }

    private void ResetTrap()
    {
        triggered = false;
    }
}
