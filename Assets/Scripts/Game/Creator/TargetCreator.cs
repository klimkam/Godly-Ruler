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
    //public static List<Target> Targets = new List<Target>();
    public static event Action OnRemove;
    private void Awake()
    {
        for (int i = 0; i < _countOfAngels; i++)
        {
            Target target = Create(_prefabs.GetRandomElementFromList(), _points.GetRandomElementFromList().position);
            target.Health.OnDie += Remove;
        }
       // Targets = _listOfCreatedPrefabs;
    }
    private void Remove(Health health)
    {
        Target target = ListOfCreatedPrefabs.Find(e => e.Health.CurrentHealth == health.CurrentHealth);
        target.Health.OnDie -= Remove;
        ListOfCreatedPrefabs.Remove(target);
        //Targets = _listOfCreatedPrefabs;
       Destroy(target.gameObject);
        OnRemove?.Invoke();
        FindObjectsOfType<CheckerEntitieNearby>().ToList().ForEach(e => e.SortByObject());
        /*List<CheckerDemonNearby> checkerDemonNearbies = FindObjectsOfType<CheckerDemonNearby>().ToList();
        List<CheckerAngelNearby> checkerAngelNearby = FindObjectsOfType<CheckerAngelNearby>().ToList();
        checkerDemonNearbies.ForEach(e => e.SortByObject());
        checkerAngelNearby.ForEach(e => e.SortByObject());*/
    }
    private void OnDisable()
    {
        ListOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
