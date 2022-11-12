using UnityEngine;

public class AngelMovement : IMovable
{
    private MovementByMoveTowards _movementByMoveTowards;
    private readonly float _range = 1;
    private bool _canMove;
    private Vector3 _targetPosition;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public MovementByMoveTowards MovementByMoveTowards => _movementByMoveTowards;
    public void Move()
    {
        _movementByMoveTowards.Move(_targetPosition, _speed, _range, ref _canMove);
    }
     public AngelMovement(Transform currentTransform, Vector3 targetPosition, float speed)
    {
        _currentTransform = currentTransform;
        _targetPosition = targetPosition;
        _speed = speed;
        _canMove = true;
        _movementByMoveTowards = new MovementByMoveTowards(_currentTransform);
    }
}
 