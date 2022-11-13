using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Demon : Target, IAttackableEntitie
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Target _sortedTarget;
    private ChangerMovement _changerMovement;
    public ChangerMovement ChangerMovement { get => _changerMovement; set => _changerMovement = value; }
    public Target SortedTarget { get => _sortedTarget; set => _sortedTarget = value; }
    public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }

    [SerializeField] private protected ChangerTime _changerTime;
    [SerializeField] private protected float _range = 6;
    [SerializeField] private protected CheckerEntitieNearby _checkerEntitieNearby;
    private void Awake()
    {
        ChangerMovement = new ChangerMovement(this);
        _navMeshAgent.TurnOffNavmesh();
        _navMeshAgent.speed = Speed;
        Debug.Log(_navMeshAgent.speed + " WE NEeD SPEED " + Speed);
        ChangerMovement.ChangeMovement(new StayState());
        _checkerEntitieNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    private void Update()
    {
        if(IAttack == null || IMovable == null)
        {
            return;
        }
        if(IMovable.CurrentTransform != null)
        {
            IMovable.Move();
        }
        if (IAttack.Health != null)
        {
            IAttack.Attack();
        }
        }
    protected abstract void SetNewRangerAttack();
    private void OnDisable()
    {
        _checkerEntitieNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
