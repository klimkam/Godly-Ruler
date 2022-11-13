using UnityEngine;
using UnityEngine.AI;
public interface IMovable
{
    MovementByNavmech MovementByNavMech { get; }
    Transform CurrentTransform { get;}
    float Speed { get; set; }
    void Move();
}
