using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTrigger<T> : Trigger where T : Target
{
    [SerializeField] private Bullet _bullet;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        OnTrigger<T>(collision, (item) =>
        {
            Destroy(gameObject);
        });
    }
}
