using UnityEngine;

public class AngelMovement : IMovable
{
    private readonly float _range = 1;
    private bool _canMove;
    private Vector3 _targetPosition;
    private float _speed;
    private Transform _currentTransform;
    public Transform CurrentTransform { get => _currentTransform; set => _currentTransform = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Vector3 TargetPosition { get => _targetPosition; set => _targetPosition = value; }
    public void Move()
    {
        if (_canMove)
        {
            _currentTransform.position = Vector3.MoveTowards(_currentTransform.position, _targetPosition, _speed * Time.deltaTime);
            if (Vector2.Distance(_currentTransform.position, _targetPosition) < _range)
            {
                _canMove = false;
            }
        }
    }
     public AngelMovement(Transform currentTransform, Vector3 targetPosition, float speed)
    {
        _currentTransform = currentTransform;
        _targetPosition = targetPosition;
        _speed = speed;
        _canMove = true;
    }
}
