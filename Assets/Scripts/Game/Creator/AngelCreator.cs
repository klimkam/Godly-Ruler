using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelCreator : Creator<Angel>
{
    [SerializeField] private int _countOfAngels = 6;
    [SerializeField] private Transform _point;
    private float _dectroyTime = 0.3f;
    private void Awake()
    {
        for(int i = 0; i < _countOfAngels; i++)
        {
           Angel angel = Create(_prefabs.GetRandomElementFromList(), _point.position);
            angel.Health.OnDie += Remove; 
        }
    }
    private void Remove(Health health)
    {
        Angel angel = _listOfCreatedPrefabs.Find(e => e.Health.CurrentHealth == health.CurrentHealth);
        angel.Health.OnDie -= Remove;
        _listOfCreatedPrefabs.Remove(angel);
        Destroy(angel.gameObject, _dectroyTime);
    }
    private void OnDisable()
    {
        _listOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
