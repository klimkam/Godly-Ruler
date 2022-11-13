using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRanger : Demon
{
    [SerializeField] protected CreatorBullet _creatorBullet;
    [SerializeField] private CheckerAngelNearby _checkerAngelNearby;
    private void OnEnable()
    {
        _checkerAngelNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
        _checkerAngelNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    protected override void SetNewRangerAttack()
    {
        IAttack = new RangerAttack(transform, this, _checkerAngelNearby.ClosestTarget.Health, _changerTime, _creatorBullet, _range);
        ChangerMovement.ChangeMovement(new RangerMovement(transform, _checkerAngelNearby.ClosestTarget.transform,Speed));
    }
    private void OnDisable()
    {
        _checkerAngelNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
