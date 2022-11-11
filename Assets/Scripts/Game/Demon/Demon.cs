using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Demon : Target
{
    public void Update()
    {
        IMovable?.Move();
    }

}
