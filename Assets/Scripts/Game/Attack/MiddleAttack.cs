using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleAttack : IAttack
{
    private readonly float _damage;
    private Health _health;
    public Health Health { get => _health; set => _health = value; }

    public void Attack()
    {
        _health.DecreaseHealth(_damage);
    }
    public MiddleAttack(Health health,float damage)
    {
        _health = health;
        _damage = damage;
    }
}
