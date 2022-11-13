using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Demon : Target, IAttackableEntitie
{
    [SerializeField] private Target _sortedTarget;
    private ChangerMovement _changerMovement;
    public ChangerMovement ChangerMovement { get => _changerMovement; set => _changerMovement = value; }
    public Target SortedTarget { get => _sortedTarget; set => _sortedTarget = value; }
    [SerializeField] private protected ChangerTime _changerTime;
    [SerializeField] private protected float _range = 6;
    private void Awake()
    {
        ChangerMovement = new ChangerMovement(this);
        ChangerMovement.ChangeMovement(new StayState());
    }
    private void Update()
    {
        IMovable?.Move();
        if(IAttack == null)
        {
            return;
        }
        if (IAttack.Health != null)
        {
            IAttack.Attack();
        }
        }
    protected abstract void SetNewRangerAttack();
}
