using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerDemonNearby : Trigger
{
    [SerializeField] private Angel _angel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<Demon>(collision, (demon) =>
         {
             _angel.IMovable = new MovementToTarget(_angel.transform,demon.transform,_angel.Speed);
         });
    }
}
