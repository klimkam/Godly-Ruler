using UnityEngine;

public class Angel : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private AngelBacklight _angelBacklight;
    private IMovable _iMovable;
    public AngelBacklight AngelBacklight { get => _angelBacklight; private set => _angelBacklight = value; }

    public void StartMoving(Vector3 target)
    {
        _iMovable = new AngelMovement(transform, target, _speed);
    }
    private void Update()
    {
        _iMovable?.Move();
    }
}
