using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerAngel : Angel
{
    private void OnEnable()
    {
        _checkerEntitieNearby.SorterEntitiesBy = new SorterEntitiesByHealth(SortedTarget);
    }
    public override void SetNewRangerAttack()
    {
        if (_reseterTimerByClick.IsCoolDown)
        {
            return;
        }
        IAttack = new HealAttack(transform, this, _checkerEntitieNearby.ClosestTarget.Health, _changerTime, Damage, _range);
        ChangerMovement.ChangeMovement(new MovementToTarget(NavMeshAgent, _checkerEntitieNearby.ClosestTarget.transform, Speed));
        IMovable.Move();

    }

}
