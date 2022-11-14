using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class CollectorOfTargets : MonoBehaviour
{
    [SerializeField] private List<TargetCreator> _targetCreators = new List<TargetCreator>();
    private List<Target> _allTargets = new List<Target>();
    public List<Target> AllTargets { get => _allTargets; private set => _allTargets = value; }
    public event Action<Target> OnRemoveTaget;
    private void Awake()
    {
       // _targetCreators = FindObjectsOfType<TargetCreator>().ToList();
        _targetCreators.ForEach(e => e.OnCreate += Add);
        _targetCreators.ForEach(e => e.OnRemove += Remove);
    }
    private void Add(Target target)
    {
        _allTargets.Add(target);
        SetTargets();
    }
    private List<CheckerEntitieNearby> FindCheckers() => FindObjectsOfType<CheckerEntitieNearby>().ToList();
    private void SetTargets()
    {
        //FindCheckers().ForEach(e => e.ListOfCreatedTargets = _allTargets);
    }
    public void Remove(Target target)
    {
        _allTargets.Remove(target);
        OnRemoveTaget?.Invoke(target);
        List<CheckerEntitieNearby> checkerEntitieNearbies = FindCheckers();
        SetTargets();
        checkerEntitieNearbies.ForEach(e => e.FindClosest());
    }
    private void OnDisable()
    {
        _targetCreators.ForEach(e => e.OnCreate -= Add);
        _targetCreators.ForEach(e => e.OnRemove -= Remove);
    }
}
