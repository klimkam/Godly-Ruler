using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckerDemonNearby : CheckerEntitieNearby
{
    
    public override List<Target> SortEntieits()
    {
        return _sorterEntitiesBy.Sort(_targets);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTrigger<Demon>(collision, (target) =>
        {
            if (_targets.Contains(target) == false)
            {
                _targets.Add(target);
            }
        });
        SortByObject();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTrigger<Demon>(collision, (target) =>
        {
            if (_targets.Contains(target))
            {
                Debug.Log(" We EXIT DEMON! " + target);
                _targets.Remove(target);
            }
            _closestTarget = null;
            _previousTarget = null;

        });
        SortByObject();
    }
}
