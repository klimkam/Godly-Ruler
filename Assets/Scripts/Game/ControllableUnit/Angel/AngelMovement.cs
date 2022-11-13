using UnityEngine;
using UnityEngine.AI;

public class AngelMovement : IMovable
{
    private MovementByNavmech _movementByMoveTowards;
    private readonly float _range = 1;
    private bool _canMove;
    private Vector3 _targetPosition;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByNavmech MovementByMoveTowards => _movementByMoveTowards;

    public void Move()
    {
        _movementByMoveTowards.Move(_targetPosition, _speed, _range, ref _canMove);
    }
     public AngelMovement(NavMeshAgent navMeshAgent, Vector3 targetPosition, float speed)
    {
        _currentTransform = navMeshAgent.transform;
        _targetPosition = targetPosition;
        _speed = speed;
        _canMove = true;
        _movementByMoveTowards = new MovementByNavmech(navMeshAgent);
    }
}
 