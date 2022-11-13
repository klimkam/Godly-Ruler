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
    [SerializeField] private ChangerTime _changerTime;
    public static event Action OnRemove;
    private void Awake()
    {
        _changerTime.IsCoolDown = true;
        Create();
        _changerTime.SetReloadTime(() =>
        {
            Create();
            _changerTime.IsCoolDown = true;
        });
    }
    private void Create()
    {
        Target target = Create(Prefabs.GetRandomElementFromList(), _points.GetRandomElementFromList().position);
        target.Health.OnDie += Remove;
    }
    private void Remove(Health health)
    {
        Target target = ListOfCreatedPrefabs.Find(e => e.Health.CurrentHealth == health.CurrentHealth);
        target.Health.OnDie -= Remove;
        ListOfCreatedPrefabs.Remove(target);
       Destroy(target.gameObject);
        OnRemove?.Invoke();
        FindObjectsOfType<CheckerEntitieNearby>().ToList().ForEach(e => e.SortByObject());
    }
    private void OnDisable()
    {
        ListOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
