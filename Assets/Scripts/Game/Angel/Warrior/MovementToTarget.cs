using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToTarget : IMovable
{
    private MovementByMoveTowards _movementByMoveTowards;
    private readonly float _range = 1;
    private bool _canMove;
    private Transform _targetPoint;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByMoveTowards MovementByMoveTowards => _movementByMoveTowards;
    public void Move()
    {
        _movementByMoveTowards.Move(_targetPoint.position, _speed, _range, ref _canMove);
    }
    public MovementToTarget(Transform currentTransform, Transform target, float speed)
    {
        _currentTransform = currentTransform;
        _targetPoint = target;
        _speed = speed;
        _canMove = true;
        _movementByMoveTowards = new MovementByMoveTowards(_currentTransform);
    }
}
