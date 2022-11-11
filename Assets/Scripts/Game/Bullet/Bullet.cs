using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _damage = 1;
    private IMovable _iMovable;

    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public float Damage { get => _damage; set => _damage = value; }

    public void SetTarget(Transform target)
    {
        _iMovable = new MovementToTarget(transform, target, _speed);
    }
    private void Update()
    {
        IMovable?.Move();
    }
}
