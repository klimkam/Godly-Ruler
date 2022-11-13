using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SorterEntitiesBy
{
    protected Target _target;
    public abstract List<Target> Sort(List<Target> list);
}
