using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByMoveTowards 
{
   private Transform _currentTransform; 
   public void Move(Vector3 target,float speed, float range, ref bool canMove)
   {
        if (canMove)
        {
            _currentTransform.position = Vector3.MoveTowards(_currentTransform.position, target, speed * Time.deltaTime);
            if (Vector2.Distance(_currentTransform.position, target) < range)
            {
              canMove = false;
            }
        }
    }
    public MovementByMoveTowards(Transform currentTransform)
    {
        _currentTransform = currentTransform;
    }
}
