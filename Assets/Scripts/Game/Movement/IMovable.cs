using UnityEngine;

public interface IMovable
{
    MovementByMoveTowards MovementByMoveTowards { get; }
    Transform CurrentTransform { get;}
    float Speed { get; set; }
    void Move();
}
