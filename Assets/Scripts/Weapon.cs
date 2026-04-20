using System.Collections;
using UnityEngine;

public class Weapon: MonoBehaviour
{
    private int maxAmmo = 10;
    private int currentAmmo;
    
    [SerializeField] private Bullet bulletPrefab;
    private ObjectPool<Bullet> _pool;
    

    private Coroutine reloadCoroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(bulletPrefab);
    }

    private void CancelReload()
    {
        StopCoroutine(reloadCoroutine);
    }

    private IEnumerator ShootContinuously()
    {
        while (true)
        {
            if (currentAmmo > 0)
            {
                // shoot logic 
            }
            else
            {
                yield return Reload();
            }
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0)
        {
            // shoot logic
            Bullet bullet = _pool.Get();
            bullet.Init(ReturnToPool);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            
            _pool.Return(bullet);
        }
        else if (reloadCoroutine == null)
        {
            reloadCoroutine = StartCoroutine(Reload());
        }
    }

    private void ReturnToPool(Bullet bullet)
    {
        _pool.Return(bullet);
    }
    
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        currentAmmo = maxAmmo;
    }
}