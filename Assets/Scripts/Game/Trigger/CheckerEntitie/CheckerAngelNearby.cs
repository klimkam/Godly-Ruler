using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CheckerAngelNearby : CheckerEntitieNearby
{
    public override List<Target> SortEntieits()
    {
        return _sorterEntitiesBy.Sort(_targets);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<Angel>(collision, (target) =>
        {
            _targets.Add(target);
        });
        SortByObject();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTrigger<Angel>(collision, (target) =>
        {
            if (_targets.Contains(target))
            {
                _targets.Remove(target);
            }
            _closestTarget = null;
            _previousTarget = null;
        });
        SortByObject();
    }

}
