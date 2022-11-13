using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTrigger<T> : Trigger where T : Target
{
    [SerializeField] private protected Bullet _bullet;
}
