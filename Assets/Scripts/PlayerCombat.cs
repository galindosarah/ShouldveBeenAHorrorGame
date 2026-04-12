using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Camera playerCamera;

    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireForce;

    public float attackCooldown = 0.5f;
    private bool canAttack = true;

    private bool useAnimationEvent = true;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0) && GameStateManager.Instance.IsGameplay())
        {
            Attack();
        }
    }

    void Attack ()
    {
        if (!canAttack) return;

        canAttack = false;

        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        if (!useAnimationEvent)
        {
            SpawnFireball();
        }

        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    public void SpawnFireball()
    {
        if (fireballPrefab == null || firePoint == null) return;

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            rb.linearVelocity = ray.direction * fireForce;
        }
    }
}
