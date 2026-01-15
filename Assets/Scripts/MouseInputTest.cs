using System;
using UnityEngine;

public class MouseInputTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.TryGetComponent<IKillable>(out IKillable killable))
                {
                    killable.TakeDamage(100);
                }
            }
        }
    }
}