// using System;
// using UnityEngine;

// [RequireComponent(typeof(CharacterController))]
// public class FPSController : MonoBehaviour
// {
//     [SerializeField] private WeaponController m_weaponController;
//     [SerializeField] private Camera playerCamera;

//     [Header("Movement Settings")]
//     public float moveSpeed = 5f;
//     public float jumpForce = 8f;
//     public float gravity = -9.81f;

//     [Header("Look Settings")]
//     public float mouseSensitivity = 100f;

//     private CharacterController characterController;
//     private Vector3 velocity;
//     private bool isGrounded;
//     private float xRotation = 0f;

//     void Start()
//     {
//         characterController = GetComponent<CharacterController>();

//         // Lock and hide the cursor
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;

//         Enemy.OnEnemyDefeated+=Enemy_OnEnemyDefeated;
//     }

//     private void Enemy_OnEnemyDefeated(int score)
//     {
//         // Handle enemy death
//         // xp += score;
//     }

//     void Update()
//     {
//         HandleMovement();
//         HandleCamera();
//         // HandleShooting();
//         HandleInteraction();
//     }

//     private void HandleCamera()
//     {
//         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

//         // Rotate player body left-right
//         transform.Rotate(Vector3.up * mouseX);

//         // Rotate camera up-down
//         xRotation -= mouseY;
//         xRotation = Mathf.Clamp(xRotation, -90f, 90f);

//         playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//     }

//     private void HandleMovement()
//     {
//         isGrounded = characterController.isGrounded;

//         if (isGrounded && velocity.y < 0)
//         {
//             velocity.y = -2f; // Keeps player grounded
//         }

//         // Movement
//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");

//         Vector3 move = transform.right * x + transform.forward * z;
//         characterController.Move(move * moveSpeed * Time.deltaTime);

//         // Jumping
//         if (Input.GetButtonDown("Jump") && isGrounded)
//         {
//             velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
//         }

//         // Apply gravity
//         velocity.y += gravity * Time.deltaTime;
//         characterController.Move(velocity * Time.deltaTime);
//     }

//     // private void HandleShooting()
//     // {
//     //     if (Input.GetMouseButtonDown(0))
//     //     {
//     //         m_weaponController?.Attack();
//     //     }
//     // }

//     private void HandleInteraction()
//     {
//         if (Input.GetKeyDown(KeyCode.E))
//         {
//             Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

//             if (Physics.Raycast(ray, out RaycastHit hit, 10f))
//             {
//                 // Try Interactable
//                 if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
//                 {
//                     interactable.Interact();
//                 }

//                 // Try Damageable
//                 if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
//                 {
//                     damageable.TakeDamage(10);
//                 }
//             }
//         }
//     }
// }
