using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayState : IMovable
{
    public MovementByMoveTowards MovementByMoveTowards => throw new System.NotImplementedException();

    public Transform CurrentTransform => throw new System.NotImplementedException();

    public float Speed { get; set; }

    public void Move()
    {

    }
}
