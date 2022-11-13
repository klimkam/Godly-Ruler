using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterEntitiesByHealth : SorterEntitiesBy
{
    public override List<Target> Sort(List<Target> list)
    {
        SorterEntitiesBy sorterEntitiesBy = new SorterEntitiesByType(_target);
        list = sorterEntitiesBy.Sort(list);
        if (list != null)
        {
            list.Sort(delegate (Target firstTarget, Target secondTarget)
            {
                return firstTarget.Health.CurrentHealth.CompareTo(secondTarget.Health.CurrentHealth);
            });
        }
            return list;
    }
    public SorterEntitiesByHealth(Target target)
    {
        _target = target;
    }
}
