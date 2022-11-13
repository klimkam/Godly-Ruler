using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealer : Demon
{
    private void OnEnable()
    {
        _checkerEntitieNearby.SorterEntitiesBy = new SorterEntitiesByHealth(SortedTarget);
    }
    protected override void SetNewRangerAttack()
    {
        IAttack = new HealAttack(transform, this, _checkerEntitieNearby.ClosestTarget.Health, _changerTime, Damage, _range);
        ChangerMovement.ChangeMovement(new MovementToTarget(NavMeshAgent, _checkerEntitieNearby.ClosestTarget.transform, Speed));
    }
}
