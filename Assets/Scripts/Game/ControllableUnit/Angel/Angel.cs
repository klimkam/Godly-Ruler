using UnityEngine;
using UnityEngine.AI;
public abstract class Angel : ControllableUnit, IAttackableEntitie
{
    [SerializeField] private GameObject _miniMapAngel;
    [SerializeField] private protected CheckerEntitieNearby _checkerEntitieNearby;
    [SerializeField] private Target _sortedTarget;
    [SerializeField] private protected ChangerTime _reseterTimerByClick;
    [SerializeField] private protected float _range = 6;
    [SerializeField] private protected ChangerTime _changerTime;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private Vector2 _lastTargetPosition;
    private ChangerMovement _changerMovement;
    public ChangerMovement ChangerMovement { get => _changerMovement; set => _changerMovement = value; }
    public Target SortedTarget { get => _sortedTarget; set => _sortedTarget = value; }
    public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }

    private void Awake()
    {
        _miniMapAngel.SetActive(true);
        _changerMovement = new ChangerMovement(this);
        _navMeshAgent.TurnOffNavmesh();
        _navMeshAgent.speed = Speed;
        _checkerEntitieNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    public void SetAngelMovement()
    {
        ChangerMovement.ChangeMovement(new AngelMovement(_navMeshAgent, _lastTargetPosition, Speed));
    }
    public override void OnClick(Vector3 target)
    {
        _reseterTimerByClick.ResetTimer();
        _lastTargetPosition = target;
        SetAngelMovement();
    }
    public abstract void SetNewRangerAttack();
    private void Update()
    {
        if (IAttack != null )
        {
            
            if (IAttack.Health != null)
            {
                IAttack.Attack();
            }
        }
        if (IMovable != null)
        {
            if (IMovable.MovementByNavMech != null)
            {
                if (IMovable.MovementByNavMech.NavMeshAgent != null)
                {
                    IMovable.Move();
                }
            }
        }
    }

    private void OnDisable()
    {
        _checkerEntitieNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }

}
