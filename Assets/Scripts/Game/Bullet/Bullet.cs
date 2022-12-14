using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _damage = 1;
    private IMovable _iMovable;
    private Transform _target;
    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public void SetTarget(Transform target)
    {
        _iMovable = new MovementByMoveTowards(transform, target, _speed);
        _target = target;
    }
    private void Update()
    {
        if (IMovable == null)
        {
            return;
        }
        if (_target != null)
        {
            IMovable?.Move();
        }
     }
    }
