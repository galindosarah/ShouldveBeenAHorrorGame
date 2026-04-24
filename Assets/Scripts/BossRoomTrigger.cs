// DIG 3878
// Sarah Galindo
// Sets up boss room trigger for boss to chase player when they enter the boss room.

using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    public BossChase bossChase;
    public GemUI gemUI;
    public GameObject bossHealthUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossChase.playerInBossRoom = true;
            
            if (gemUI != null)
            {
                gemUI.enabled = false;
            }
            if (bossHealthUI != null)
            {
                bossHealthUI.SetActive(true);
            }

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                playerHealth.SetHealthFromGems();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossChase.playerInBossRoom = false;
        }
    }
    
}