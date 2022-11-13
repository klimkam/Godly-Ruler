using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayState : IMovable
{
    private Transform _transform;
    public MovementByNavmech MovementByNavMech { get; }

    public Transform CurrentTransform => _transform;

    public float Speed { get; set; }

    public void Move()
    {

    }
}
