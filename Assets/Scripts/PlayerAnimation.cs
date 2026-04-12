using UnityEngine;
using DigitalWorlds;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public RigidbodyFPSController controller;
    public Rigidbody rb;
    void Start()
    {
        controller.OnJump += HandleJump;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;
        animator.SetFloat("Speed", speed);

        bool grounded = Mathf.Abs(rb.linearVelocity.y) < 0.1f;
        animator.SetBool("IsGrounded", grounded);
    }

    void HandleJump()
    {
        animator.SetTrigger("Jump");
    }

}
