using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<T> _prefabs;
    protected List<T> listOfCreatedPrefabs = new List<T>();

    public List<T> ListOfCreatedPrefabs { get => listOfCreatedPrefabs; private  set => listOfCreatedPrefabs = value; }

    public T Create(T item,Vector2 vector)
    {
        T foundItem = _prefabs.Find(e => e.GetType() == item.GetType());
        if (foundItem == null)
        {
            return null;
        }
        T createdItem = Instantiate(foundItem, vector, Quaternion.identity);
        ListOfCreatedPrefabs.Add(createdItem);
        return createdItem;
    }
    }
