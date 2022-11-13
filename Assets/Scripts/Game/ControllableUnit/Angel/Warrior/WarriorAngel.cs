using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAngel : Angel
{
    [SerializeField] private CheckerDemonNearby _checkerDemonNearby;
    [SerializeField] private ChangerTime _changerTime;
    [SerializeField] private float _range = 6;
    private void OnEnable()
    {
        _checkerDemonNearby.SorterEntitiesBy = new SorterEntitiesByType(SortedTarget);
        _checkerDemonNearby.OnChangeListOfTarget += SetNewRangerAttack;
    }
    private void SetNewRangerAttack()
    {
        IAttack = new MiddleAttack(_checkerDemonNearby.ClosestTarget.Health, transform, Damage, _range, _changerTime, this);
        ChangerMovement.ChangeMovement(new MovementToTarget(transform, _checkerDemonNearby.ClosestTarget.transform, Speed));
    }
    private new void Update()
    {
        base.Update();
        if(IAttack == null)
        {
            return;
        }
        if (IAttack.Health != null)
        {
            IAttack.Attack();
        }
        }
        private void OnDisable()
    {
        _checkerDemonNearby.OnChangeListOfTarget -= SetNewRangerAttack;
    }
}
