using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IAttackableEntitie 
{
  NavMeshAgent NavMeshAgent { get; set; }
  ChangerMovement ChangerMovement { get; set; }
  Target SortedTarget { get; set; }
}
