// DIG 3878
// Annette Gonzalez
// This script allows the boss to chase the player.

using UnityEngine;

public class BossChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float attackDistance = 2f;
    public float attackCooldown = 1.5f;
    public float chaseRange = 10f;

    private Rigidbody rb;
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = (player.position - transform.position).normalized;

        if (distance <= chaseRange && distance > attackDistance)
        {
            rb.linearVelocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);

            Vector3 lookPos = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookPos);
        }
        else if (distance <= attackDistance)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            TryAttack();
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            lastAttackTime = Time.time;
        }
    }
}
