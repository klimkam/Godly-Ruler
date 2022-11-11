using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _damage = 2;
    private IMovable _iMovable;
    private IAttack _iAttack;
    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public float Speed { get => _speed; private set => _speed = value; }
    public IAttack IAttack { get => _iAttack; set => _iAttack = value; }
    public Health Health { get => _health; private set => _health = value; }
    public float Damage { get => _damage; private set => _damage = value; }
}
