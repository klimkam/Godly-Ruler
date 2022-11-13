using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : IAttack
{
    private readonly Transform _currentTransform;
    private readonly float _range;
    private readonly ChangerTime _changerTime;
    private readonly CreatorBullet _creatorBullet;
    private Health _health;
    public Health Health { get => _health; set => _health = value; }
    public void Attack()
    {
        if(_changerTime.IsCoolDown)
        {
            return;
        }
        /*if (Vector2.Distance(_currentTransform.position, _health.transform.position) <= _range)
        {
           Bullet bullet = _creatorBullet.CreateBullet();
            bullet.SetTarget(_health.transform);
            _changerTime.IsCoolDown = true;
        }*/
    }
    public RangerAttack(Transform currentTransform, Health health,ChangerTime changerTime, CreatorBullet creatorBullet, float range)
    {
        _changerTime = changerTime;
        _currentTransform = currentTransform;
        _health = health;
        _range = range;
        _creatorBullet = creatorBullet;
    }
}
