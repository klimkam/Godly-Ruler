using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAttack : IAttack
{
    private IAttackableEntitie _iAttackableEntitie;
    private readonly Transform _currentTransform;
    private readonly float _range;
    private readonly ChangerTime _changerTime;
    private readonly float _attackTime = 2;
    private readonly float _additionalHealth;
    private bool _canMove = true;
    private Health _health;
    public Health Health { get => _health; set => _health = value; }
    public void Attack()
    {
        Debug.Log("TRY HEAL!");
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
            Debug.Log("HEAL !" + _health);
            _health.IncreaseHealth(_additionalHealth);
            _changerTime.IsCoolDown = true;
            _iAttackableEntitie.ChangerMovement.ChangeMovement(new StayState());
            _canMove = true;
        }
    }
    public HealAttack(Transform currentTransform, IAttackableEntitie attackableEntitie, Health health, ChangerTime changerTime, float damage, float range)
    {
        _iAttackableEntitie = attackableEntitie;
        _changerTime = changerTime;
        _currentTransform = currentTransform;
        _health = health;
        _range = range;
        _additionalHealth = damage;
    }
}
