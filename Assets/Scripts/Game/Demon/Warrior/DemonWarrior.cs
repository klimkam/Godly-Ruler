using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWarrior : Demon
{
    [SerializeField] private CheckerAngelNearby _checkerAngelNearby;
    private void OnEnable()
    {
        _checkerAngelNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
        _checkerAngelNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    protected override void SetNewRangerAttack()
    {
        IAttack = new MiddleAttack(_checkerAngelNearby.ClosestTarget.Health, transform, Damage, _range, _changerTime, this);
        ChangerMovement.ChangeMovement(new MovementToTarget(transform, _checkerAngelNearby.ClosestTarget.transform, Speed));
    }
    private void OnDisable()
    {
        _checkerAngelNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
