using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public abstract class Demon : Target, IAttackableEntitie
{
    private HumanVillage _humanVillage;
    [SerializeField] private GameObject _miniMapDemon;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Target _sortedTarget;
    private ChangerMovement _changerMovement;
    private readonly float _minDemonSanityLevel = -50f;
    [SerializeField] private protected ChangerTime _changerTime;
    [SerializeField] private protected float _range = 6;
    [SerializeField] private protected CheckerEntitieNearby _checkerEntitieNearby;
    public ChangerMovement ChangerMovement { get => _changerMovement; set => _changerMovement = value; }
    public Target SortedTarget { get => _sortedTarget; set => _sortedTarget = value; }
    public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }

    private void Awake()
    {
        _miniMapDemon.SetActive(true);
        ChangerMovement = new ChangerMovement(this);
        _navMeshAgent.TurnOffNavmesh();
        _navMeshAgent.speed = Speed;
        _checkerEntitieNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    private void Start()
    {
        _humanVillage = GetClosestVillage();
        ChangerMovement.ChangeMovement(new MovementToTarget(_navMeshAgent, _humanVillage.transform, Speed));
    }
    private HumanVillage GetClosestVillage()
    {
        List<HumanVillage> humanVillages = FindObjectsOfType<HumanVillage>().ToList();
        humanVillages.RemoveAll(e => e.SanityLevel <= _minDemonSanityLevel);
        Debug.Log(humanVillages.Count + " COUNT");
        List<HumanVillage> sortedVillages = humanVillages.SortListByDistance(transform);
        if (sortedVillages.Any(e => e.SanityChangeRante == 0))
        {
            sortedVillages.OrderByDescending(e => e.SanityChangeRante == 0);

        }
        return sortedVillages.FirstOrDefault();
    }
    private void Update()
    {
        if (IAttack != null)
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
    protected abstract void SetNewRangerAttack();
    private void OnDisable()
    {
        _checkerEntitieNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
