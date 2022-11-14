using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleAttack : IAttack
{
    private IAttackableEntitie _iAttackableEntitie;
    private Transform _currentTransform;
    private readonly ChangerTime _changerTime;
    private readonly float _damage;
    private readonly float _attackTime = 2;
    private bool _canMove = true;
    private Health _health;
    private readonly float _range;
    public Health Health { get => _health; set => _health = value; }

    public void Attack()
    {
        if (_changerTime.CurrentTime > _attackTime && _canMove)
        {
            _iAttackableEntitie.ChangerMovement.SetPreviousMovement();
            _canMove = false;
        }
        if (_changerTime.IsCoolDown)
        {
            return;
        }
        if (Vector2.Distance(_currentTransform.position, _health.transform.position) <= _range)
        {
            Debug.Log(" DAMAGE " + _damage);
            _health.DecreaseHealth(_damage);
            _changerTime.IsCoolDown = true;
            _iAttackableEntitie.ChangerMovement.ChangeMovement(new StayState());
            _canMove = true;
        }
    }
    public MiddleAttack(Health health,Transform currentTransform, float damage, float range, ChangerTime changerTime, IAttackableEntitie iAttackableEntitie)
    {
        _currentTransform = currentTransform;
        _health = health;
        _damage = damage;
        _range = range;
        _changerTime = changerTime;
        _iAttackableEntitie = iAttackableEntitie;
    }
}
