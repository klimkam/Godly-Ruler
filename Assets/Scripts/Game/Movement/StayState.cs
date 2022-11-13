using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayState : IMovable
{
    private Transform _transform;
    public MovementByNavmech MovementByMoveTowards => throw new System.NotImplementedException();

    public Transform CurrentTransform => _transform;

    public float Speed { get; set; }

    public void Move()
    {

    }
}
