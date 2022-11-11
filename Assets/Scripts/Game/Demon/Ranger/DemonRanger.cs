using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRanger : Demon
{
    [SerializeField] private CreatorBullet _creatorBullet;
    [SerializeField] private CheckerAngelNearby _checkerAngelNearby;
    [SerializeField] private ChangerTime _changerTime;
    private float _range = 6;
    private void OnEnable()
    {
        _checkerAngelNearby.OnChangeListOfAngels += SetNewRangerAttack;
    }
    private void SetNewRangerAttack()
    {
        IAttack = new RangerAttack(transform, _checkerAngelNearby.ClosestAngel.Health, _changerTime, _creatorBullet, _range);
    }
    private new void Update()
    {
        base.Update();
        IAttack?.Attack();
    }
    private void OnDisable()
    {
        _checkerAngelNearby.OnChangeListOfAngels -= SetNewRangerAttack;
    }
}
