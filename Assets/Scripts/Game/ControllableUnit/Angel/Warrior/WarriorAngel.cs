using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAngel : Angel
{
    private void OnEnable()
    {
        _checkerEntitieNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
    }
    public override void SetNewRangerAttack()
    {
        if(_reseterTimerByClick.IsCoolDown)
        {
            return;
        }
        Debug.Log("HI! I AM ANGEL WARRIOR! NOW I AM ATTACKING!");
        IAttack = new MiddleAttack(_checkerEntitieNearby.ClosestTarget.Health, transform, Damage, _range, _changerTime, this);
        ChangerMovement.ChangeMovement(new MovementToTarget(NavMeshAgent, _checkerEntitieNearby.ClosestTarget.transform, Speed));
        IMovable.Move();
    }
}
