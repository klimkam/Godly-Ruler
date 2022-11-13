using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMovement : IMovable
{
    private MovementByMoveTowards _movementByMoveTowards;
    private readonly float _range = 0.2f;
    private bool _canMove;
    private Transform _targetPoint;
    private float _speed;
    private float _rangeForPositiveSpeed = 4; 
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByMoveTowards MovementByMoveTowards => _movementByMoveTowards;
    public void Move()
    {
        int valueOfPositivity = Vector2.Distance(_currentTransform.position, _targetPoint.position) < _rangeForPositiveSpeed ? -1 : 0;
        _movementByMoveTowards.Move(_targetPoint.position, _speed * valueOfPositivity, _range, ref _canMove);
   }
    public RangerMovement(Transform currentTransform, Transform target, float speed)
    {
        _currentTransform = currentTransform;
        _targetPoint = target;
        _speed = speed;
        _canMove = true;
        _movementByMoveTowards = new MovementByMoveTowards(_currentTransform);
    }
}
