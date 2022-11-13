using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SorterEntitiesByType : SorterEntitiesBy
{
    public override List<Target> Sort(List<Target> list)
    {
        if (list.Any(e => e.GetType() == _target.GetType()))
        {
           return list.OrderByDescending(e => e.GetType() == _target.GetType()).ToList();
        }
        return null;
    }
    public SorterEntitiesByType(Target target)
    {
        _target = target;
    }
}
