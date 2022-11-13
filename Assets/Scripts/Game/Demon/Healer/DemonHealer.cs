using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealer : Demon
{
    [SerializeField] private CheckerDemonNearby _checkerDemonNearby;
    private void OnEnable()
    {
        _checkerDemonNearby.SorterEntitiesBy = new SorterEntitiesByHealth(SortedTarget);
        _checkerDemonNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    protected override void SetNewRangerAttack()
    {
        IAttack = new HealAttack(transform, this, _checkerDemonNearby.ClosestTarget.Health, _changerTime, Damage, _range);
        ChangerMovement.ChangeMovement(new MovementToTarget(transform, _checkerDemonNearby.ClosestTarget.transform, Speed));
    }
    private void OnDisable()
    {
        _checkerDemonNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
