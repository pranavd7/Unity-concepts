using UnityEditor.Animations;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public AnimatorControllerLayer animatorControllerLayer;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpPower = 5f;

    float verticalVelocity;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        float magnitude = direction.magnitude;

        // Animation parameter
        animator.SetFloat("Speed", magnitude);

        animator.SetFloat("MoveX", (isShiftPressed ? 2 : 1) * direction.x);
        animator.SetFloat("MoveY", (isShiftPressed ? 2 : 1) * direction.z);

        if (controller.isGrounded)
        {
            animator.SetBool("IsGrounded", true);

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpPower;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }

        // Gravity
        verticalVelocity += gravity * Time.deltaTime;

        // Movement
        // Vector3 velocity = Vector3.zero;
        Vector3 velocity = direction.normalized * speed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);


    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable component))
            {
                component.TakeDamage(10);
            }
            if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }    

    private void GetDamageableComponent(out IDamageable damageable)
    {
        damageable = null;
    }
}
