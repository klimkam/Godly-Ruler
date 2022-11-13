using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : IAttack
{
    private IAttackableEntitie _iAttackableEntitie;
    private readonly Transform _currentTransform;
    private readonly float _range;
    private readonly ChangerTime _changerTime;
    private readonly CreatorBullet _creatorBullet;
    private readonly float _attackTime = 2;
    private bool _canMove = true;
    private Health _health;
    public Health Health { get => _health; set => _health = value; }
    public void Attack()
    {
        if(_changerTime.CurrentTime > _attackTime  && _canMove)
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
           Bullet bullet = _creatorBullet.CreateBullet();
            bullet.SetTarget(_health.transform);
            _changerTime.IsCoolDown = true;
            _iAttackableEntitie.ChangerMovement.ChangeMovement(new StayState());
            _canMove = true;
        }
    }
    public RangerAttack(Transform currentTransform, IAttackableEntitie attackableEntitie, Health health,ChangerTime changerTime, CreatorBullet creatorBullet, float range)
    {
        _iAttackableEntitie = attackableEntitie;
        _changerTime = changerTime;
        _currentTransform = currentTransform;
        _health = health;
        _range = range;
        _creatorBullet = creatorBullet;
    }
}
