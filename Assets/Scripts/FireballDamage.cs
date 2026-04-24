// DIG 3878
// Annette Gonzalez
// This script allows the fireball to damage the boss.

using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter(Collision collision)
    {
        BossHealth boss = collision.gameObject.GetComponent<BossHealth>();

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}
