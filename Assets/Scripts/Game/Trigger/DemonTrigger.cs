using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTrigger : Trigger
{
    [SerializeField] private Demon _demon;
    [SerializeField] private float _coolDown = 2;
    private bool _isReloaded = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isReloaded)
        {
            OnTrigger<Angel>(collision, e =>
            {
                e.Health.DecreaseHealth(_demon.Damage);
                StartCoroutine(CoolDown());
            });
        }
    }
    private IEnumerator CoolDown()
    {
        _isReloaded = false;
        yield return new WaitForSeconds(_coolDown);
        _isReloaded = true;
    }
}
