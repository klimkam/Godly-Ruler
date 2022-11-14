using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAngel : Angel
{
    [SerializeField] private CreatorBullet _creatorBullet;
    private void OnEnable()
    {
        _checkerEntitieNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
    }
    public override void SetNewRangerAttack()
    {
        if (_reseterTimerByClick.IsCoolDown)
        {
            return;
        }
        IAttack = new RangerAttack(transform, this, _checkerEntitieNearby.ClosestTarget.Health, _changerTime, _creatorBullet, _range);
        ChangerMovement.ChangeMovement(new RangerMovement(NavMeshAgent, _checkerEntitieNearby.ClosestTarget.transform, Speed));
        IMovable.Move();
    }

}
