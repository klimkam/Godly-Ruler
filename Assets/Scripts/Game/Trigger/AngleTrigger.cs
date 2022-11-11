using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTrigger : Trigger
{
    [SerializeField] private Angel _angel;
    [SerializeField] private ChangerTime _changerTime;
    [SerializeField] private float _range = 5;
    private void Update()
    {
        TrigWithDemon();
    }
    private void TrigWithDemon()
    {
        if (_changerTime.IsCoolDown)
        {
            return;
        }
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _range);
        foreach (Collider2D collider2D in collider2Ds)
        {
            OnTrigger<Demon>(collider2D, (demon) =>
            {
                _angel.IAttack = new MiddleAttack(demon.Health, _angel.Damage);
                _angel.IAttack.Attack();
                _angel.SetAngelMovement();
                _changerTime.IsCoolDown = true;
            });
        }

    }
}
