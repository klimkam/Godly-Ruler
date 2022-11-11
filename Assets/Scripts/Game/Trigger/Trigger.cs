using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    protected void OnTrigger<T>(Collider2D collider2D, Action<T> action) where T : MonoBehaviour
    {
        if(collider2D.TryGetComponent<T>(out T item))
        {
            action?.Invoke(item);
        }
    }
}
