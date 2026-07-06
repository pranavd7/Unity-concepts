using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpPower = 5f;

    float verticalVelocity;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        float magnitude = direction.magnitude;

        // Animation parameter
        animator.SetFloat("Speed", magnitude);

        float multiplier = isShiftPressed ? 2f : 1f;

        animator.SetFloat("MoveX", direction.x * multiplier, 0.1f, Time.deltaTime);
        animator.SetFloat("MoveY", direction.z * multiplier, 0.1f, Time.deltaTime);

        if (controller.isGrounded)
        {
            animator.SetBool("IsGrounded", true);

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpPower;
                animator.SetTrigger("Jump");

                // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
                verticalVelocity = jumpPower;
            }
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }

        // Gravity
        verticalVelocity += gravity * Time.deltaTime;

        // Movement
        float currentSpeed = isShiftPressed ? sprintSpeed : walkSpeed;

        Vector3 velocity = direction.normalized * currentSpeed;
        velocity.y = verticalVelocity;

        // Vector3 velocity = Vector3.zero;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleShooting()
    {
        bool isAiming = Input.GetMouseButton(1);

        animator.SetBool("IsAiming", isAiming);

        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
        float targetWeight = isAiming ? 1f : 0f;

        animator.SetLayerWeight(
            1,
            Mathf.Lerp(
                animator.GetLayerWeight(1),
                targetWeight,
                10f * Time.deltaTime));
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
    
    public void StartJump(int i)
    {
        Debug.Log("StartJump");
        verticalVelocity = jumpPower;
    }
    
    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        
        // Spawn projectile, vfx, etc
    }
}
