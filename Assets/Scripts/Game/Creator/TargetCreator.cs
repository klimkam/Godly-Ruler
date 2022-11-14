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
    private bool _isCoolDown;
    private float _currentTime;
    [SerializeField] private float _reloadTime = 5;
    public List<Transform> Points { get => _points; private set => _points = value; }

    public event Action<Target> OnRemove;
    public event Action<Target> OnCreate;
    private void Start()
    {
        CreateTarget();
    }

    
    public void CreateTarget()
    {
        Target target = Create(Prefabs.GetRandomElementFromList(), Points.GetRandomElementFromList().position);
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
