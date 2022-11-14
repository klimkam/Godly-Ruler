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
    public event Action<Target> OnRemove;
    public event Action<Target> OnCreate;
    private void Start()
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
        ListOfCreatedPrefabs.Add(target);
        //target.Health.OnDie += Remove;
        OnCreate?.Invoke(target);
    }
    public void Remove(Target target)
    {
        ListOfCreatedPrefabs.Remove(target);
        FindObjectOfType<CollectorOfTargets>().Remove(target);
        OnRemove?.Invoke(target);
    }
    private void OnDisable()
    {
        ListOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
