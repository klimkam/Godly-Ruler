using UnityEngine;

public abstract class Angel : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private AngelBacklight _angelBacklight;
    private IMovable _iMovable;
    public AngelBacklight AngelBacklight { get => _angelBacklight; private set => _angelBacklight = value; }
    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public float Speed { get => _speed; private set => _speed = value; }

    public void StartMoving(Vector3 target)
    {
        _iMovable = new AngelMovement(transform, target, Speed);
    }
    private void Update()
    {
        _iMovable?.Move();
    }
}
