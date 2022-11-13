using UnityEngine;

public abstract class Angel : ControllableUnit, IAttackableEntitie
{
    [SerializeField] private Target _sortedTarget;
    private Vector2 _lastTargetPosition;
    private ChangerMovement _changerMovement;
    public ChangerMovement ChangerMovement { get => _changerMovement; set => _changerMovement = value; }
    public Target SortedTarget { get => _sortedTarget; set => _sortedTarget = value; }
    private void Awake()
    {
        _changerMovement = new ChangerMovement(this);
    }
    public void SetAngelMovement()
    {
        ChangerMovement.ChangeMovement(new AngelMovement(transform, _lastTargetPosition, Speed));
    }
    public override void OnClick(Vector3 target)
    {
        _lastTargetPosition = target;
        SetAngelMovement();
    }
    protected void Update()
    {
        IMovable?.Move();
    }
}
