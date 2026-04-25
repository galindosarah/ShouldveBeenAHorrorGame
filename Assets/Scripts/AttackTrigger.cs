// Final
// DIG 3878
// Sarah Galindo
// Annette Gonzalez
// This script allows the player to take damage from the boss.

using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damage = 1;
    public float attackCooldown = 1.5f;

    private PlayerHealth playerHealth;
    private float lastAttackTime;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.Log("PlayerHealth not found on Player.");
            return;
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Boss attacked player.");
            playerHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }
}