using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWarrior : Demon
{
    private void OnEnable()
    {
        _checkerEntitieNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
    }
    protected override void SetNewRangerAttack()
    {
        IAttack = new MiddleAttack(_checkerEntitieNearby.ClosestTarget.Health, transform, Damage, _range, _changerTime, this);
        ChangerMovement.ChangeMovement(new MovementToTarget(NavMeshAgent, _checkerEntitieNearby.ClosestTarget.transform, Speed));
    }
}
