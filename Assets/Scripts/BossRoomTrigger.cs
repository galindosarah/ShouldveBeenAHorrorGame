// DIG 3878
// Sarah Galindo
// Sets up boss room trigger for boss to chase player when they enter the boss room.

using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    public BossChase bossChase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossChase.playerInBossRoom = true;
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