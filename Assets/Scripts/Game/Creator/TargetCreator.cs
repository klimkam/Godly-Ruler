using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

public class TargetCreator : Creator<Target>
{
    [SerializeField] private int _countOfAngels = 6;
    [SerializeField] private List<Transform> _points;
    public static event Action OnRemove;
    private void Awake()
    {
        for (int i = 0; i < _countOfAngels; i++)
        {
            Target target = Create(_prefabs.GetRandomElementFromList(), _points.GetRandomElementFromList().position);
            target.Health.OnDie += Remove;
        }
    }
    private void Remove(Health health)
    {
        Target target = _listOfCreatedPrefabs.Find(e => e.Health.CurrentHealth == health.CurrentHealth);
        target.Health.OnDie -= Remove;
        _listOfCreatedPrefabs.Remove(target);
        target.gameObject.SetActive(false);
       // Destroy(target.gameObject);
        OnRemove?.Invoke();
        FindObjectsOfType<CheckerEntitieNearby>().ToList().ForEach(e => e.SortByObject());
        /*List<CheckerDemonNearby> checkerDemonNearbies = FindObjectsOfType<CheckerDemonNearby>().ToList();
        List<CheckerAngelNearby> checkerAngelNearby = FindObjectsOfType<CheckerAngelNearby>().ToList();
        checkerDemonNearbies.ForEach(e => e.SortByObject());
        checkerAngelNearby.ForEach(e => e.SortByObject());*/
    }
    private void OnDisable()
    {
        _listOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
