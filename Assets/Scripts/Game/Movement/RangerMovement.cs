using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangerMovement : IMovable
{
    private MovementByNavmech _movementByMoveTowards;
    private readonly float _range = 0.2f;
    private bool _canMove;
    private Transform _targetPoint;
    private NavMeshAgent _navMeshAgent;
    private float _speed;
    private float _rangeForPositiveSpeed = 4; 
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByNavmech MovementByNavMech => _movementByMoveTowards;
    public void Move()
    {
        if (_targetPoint != null)
        {
            int valueOfPositivity = Vector2.Distance(_currentTransform.transform.position, _targetPoint.position) < _rangeForPositiveSpeed ? -1 : 0;
            _movementByMoveTowards.Move(_targetPoint.position, _speed * valueOfPositivity, _range, ref _canMove);
        }
    }
        public RangerMovement(NavMeshAgent navMeshAgent, Transform target, float speed)
    {
        _currentTransform = target;
        _navMeshAgent = navMeshAgent;
        _targetPoint = target;
        _speed = speed;
        _canMove = true;
        _movementByMoveTowards = new MovementByNavmech(navMeshAgent);
    }
}
