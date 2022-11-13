using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementByNavmech 
{
    private NavMeshAgent _navMeshAgent;
   public void Move(Vector3 target,float speed, float range, ref bool canMove)
   {
        if (canMove)
        {
            _navMeshAgent.SetDestination(target);
            if (Vector2.Distance(_navMeshAgent.transform.position, target) < range)
            {
              canMove = false;
            }
        }
    }
    public MovementByNavmech(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }
}
