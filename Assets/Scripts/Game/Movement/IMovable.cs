using UnityEngine;

public interface IMovable
{
    Transform CurrentTransform { get;}
    Vector3 TargetPosition { get; set; }
    float Speed { get; set; }
    void Move();
}
