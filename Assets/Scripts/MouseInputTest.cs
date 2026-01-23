using System;
using UnityEngine;

public class MouseInputTest : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.unityLogger.Log("Mouse Button Down");
            // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit raycastHit))
            // {
            // if (raycastHit.transform.TryGetComponent<IKillable>(out IKillable killable))
            // {
            //     killable.TakeDamage(100);
            // }
            //     }
            
            if (Physics.SphereCast(Vector3.zero, 2f, Vector3.left, out RaycastHit hitInfo, 100f, layerMask))
            {
                Debug.Log(hitInfo.collider.gameObject.name);
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    // take damage
                    if (hitInfo.transform.TryGetComponent(out IKillable killable))
                    {
                        killable.TakeDamage(100);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Debug.DrawRay(Vector3.zero, Vector3.right * 5f, Color.red);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, Vector3.right * 5f);
        Gizmos.DrawWireSphere(Vector3.zero, 2f);
    }
}