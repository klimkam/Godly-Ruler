using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackableEntitie 
{
  ChangerMovement ChangerMovement { get; set; }
  Target SortedTarget { get; set; }
}
