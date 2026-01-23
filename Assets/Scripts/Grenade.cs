using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDamage;
    [SerializeField] private float explosionForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }

    public void Explode()
    {
        Debug.Log("Explode");
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);
        foreach (var col in colliders)
        {
            // Apply explosion force to nearby rigidbodies.
            var rbNearby = col.attachedRigidbody;
            if (rbNearby != null && !rbNearby.isKinematic)
            {
                rbNearby.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1.0f, ForceMode.Impulse);
            }

            // Apply damage to nearby elements.
            var damageable = col.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                // Compute damage based on distance.
                float dist = Vector3.Distance(transform.position, col.ClosestPoint(transform.position));
                float normalized = Mathf.Clamp01(dist / explosionRadius); // 0 = center, 1 = edge
                float damage = maxDamage;

                // Linear damage reduction as per distance.
                damage = Mathf.Lerp(maxDamage, 0f, normalized);

                damageable.TakeDamage(Mathf.CeilToInt(damage));
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}