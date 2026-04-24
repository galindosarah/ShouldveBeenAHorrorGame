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

    private Rigidbody rb;
    private float lastAttackTime;

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            transform.LookAt(player);

            if (anim != null)
                anim.SetBool("isMoving", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("isMoving", false);

            TryAttack();
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
