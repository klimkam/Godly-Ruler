using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementByNavmech 
{
    private NavMeshAgent _navMeshAgent;

    public NavMeshAgent NavMeshAgent { get => _navMeshAgent; private set => _navMeshAgent = value; }

    public void Move(Vector3 target,float speed, float range, ref bool canMove)
   {
        if (canMove)
        {
            NavMeshAgent.SetDestination(target);
            if (Vector2.Distance(NavMeshAgent.transform.position, target) < range)
            {
              canMove = false;
            }
        }
    }
    public MovementByNavmech(NavMeshAgent navMeshAgent)
    {
        NavMeshAgent = navMeshAgent;
    }
}
