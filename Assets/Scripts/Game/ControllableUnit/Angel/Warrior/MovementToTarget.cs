using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementToTarget : IMovable
{
    private MovementByNavmech _movementByNavMech;
    private readonly float _range = 0.2f;
    private bool _canMove;
    private Transform _targetPoint;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByNavmech MovementByNavMech => _movementByNavMech;
    public void Move()
    {
        if (_targetPoint != null)
        {
            _movementByNavMech.Move(_targetPoint.position, _speed, _range, ref _canMove);
        }
    }
    public MovementToTarget(NavMeshAgent navMeshAgent, Transform target, float speed)
    {
        _currentTransform = target;
        _targetPoint = target;
        _speed = speed;
        _canMove = true;
        _movementByNavMech = new MovementByNavmech(navMeshAgent);
    }
}
