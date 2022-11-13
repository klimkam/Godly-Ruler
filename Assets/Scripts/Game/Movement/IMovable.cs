using UnityEngine;
using UnityEngine.AI;
public interface IMovable
{
    Transform CurrentTransform { get;}
    float Speed { get; set; }
    void Move();
}
