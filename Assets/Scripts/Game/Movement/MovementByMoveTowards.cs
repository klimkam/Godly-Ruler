using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByMoveTowards : IMovable
{
    private Transform _targetPoint;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public void Move()
    {
        _currentTransform.transform.position = Vector3.MoveTowards(_currentTransform.position, _targetPoint.position, _speed);
    }
    public MovementByMoveTowards(Transform currentTransform, Transform target, float speed)
    {
        _currentTransform = currentTransform;
        _targetPoint = target;
        _speed = speed;
    }
}
