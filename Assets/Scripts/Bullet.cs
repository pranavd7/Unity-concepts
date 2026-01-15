using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ObjectPool<Bullet> _pool;

    private void OnHit()
    {
        _pool.Return(this);
    }

    public void Init(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }
}