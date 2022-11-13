using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CheckerAngelNearby : CheckerEntitieNearby
{
    public override List<Target> Create()
    {
        return _targetCreator.ListOfCreatedPrefabs.Where(e => e is Angel).ToList();
    }

    public override bool TryAdd(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<Angel>(out Angel angel))
        {
            _targets.Add(angel);
            return true;
        }
        return false;
    }
    /*  private void OnTriggerEnter2D(Collider2D collision)
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
}*/

}
