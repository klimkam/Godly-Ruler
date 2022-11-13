using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerMovement
{
    private Target _target;
    private IMovable _previousMovable;
    public void ChangeMovement(IMovable movement)
    {
         movement?.Move();
        _previousMovable = _target.IMovable;
        _target.IMovable = movement;
    }
    public void SetPreviousMovement()
    {
        _target.IMovable = _previousMovable;
    }
    public ChangerMovement(Target target)
    {
        _target = target;
    }
}
