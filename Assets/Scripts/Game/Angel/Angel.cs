using UnityEngine;

public abstract class Angel : Target
{
    [SerializeField] private AngelBacklight _angelBacklight;
    private Vector2 _lastTargetPosition;
    public AngelBacklight AngelBacklight { get => _angelBacklight; private set => _angelBacklight = value; }
    public void StartMoving(Vector3 target)
    {
        _lastTargetPosition = target;
        SetAngelMovement();
    }
    public void SetAngelMovement()
    {
        IMovable = new AngelMovement(transform, _lastTargetPosition, Speed);
    }
    private void Update()
    {
        IMovable?.Move();
    }
}
