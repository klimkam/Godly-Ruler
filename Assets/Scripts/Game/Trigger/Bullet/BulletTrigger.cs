using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTrigger<T> : Trigger where T : Target
{
    [SerializeField] private protected Bullet _bullet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<T>(collision, (item) =>
        {
            item.Health.DecreaseHealth(_bullet.Damage);
            Destroy(gameObject);
        });
    }

}
