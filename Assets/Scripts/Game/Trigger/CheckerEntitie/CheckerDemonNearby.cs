using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckerDemonNearby : CheckerEntitieNearby
{
    public override List<Target> Create()
    {
        return _collectorOfTargets.AllTargets.Where(e => e is Demon).ToList();
    }

    public override bool TryAdd(Collider2D collider2D)
    {
        if(collider2D.TryGetComponent<Demon>(out Demon demon))
        {
            _targets.Add(demon);
            return true;
        }
        return false;
    }

}
