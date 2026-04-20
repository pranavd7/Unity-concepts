using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Action<Bullet> onHit;

    private void OnHit()
    {
        onHit?.Invoke(this);
    }

    public void Init(Action<Bullet> onHit)
    {
        this.onHit = onHit;
    }
}