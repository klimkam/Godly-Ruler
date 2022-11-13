using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CheckerEntitieNearby : Trigger
{
    [SerializeField] private Target _parentTarget;
    [SerializeField] private protected List<Target> _targets = new List<Target>();
    protected Target _closestTarget;
    protected Target _previousTarget;
    protected SorterEntitiesBy _sorterEntitiesBy;
    private readonly int _countOfTargets = 1;
    public Target ClosestTarget { get => _closestTarget; private set => _closestTarget = value; }
    public SorterEntitiesBy SorterEntitiesBy { get => _sorterEntitiesBy; set => _sorterEntitiesBy = value; }
    public event Action OnChangeListOfTarget;
    private void Awake()
    {
        //TargetCreator.OnRemove += RemoveTarget;
    }
    private void RemoveTarget()
    {
         //_targets.RemoveAll(e => e == null);
         SortByObject();
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<T>(collision, (target) =>
        {
            _targets.Add(target);
        });
        //SortByObject();
    }*/
 
    public void SortByObject()
    {
        if (_targets.All(e=>e == null))
        {
            return;
        }
        if (_targets.Count > _countOfTargets)
        {
            _targets.Sort(delegate (Target firstAngel, Target t2)
            {
                return Vector3.Distance(firstAngel.transform.position, _parentTarget.transform.position).CompareTo(Vector3.Distance(t2.transform.position, _parentTarget.transform.position));
            });
            if (_sorterEntitiesBy != null)
            {
                _targets = SortEntieits();
            }
        }
        _closestTarget = _targets.FirstOrDefault();
        if (_closestTarget != _previousTarget || _previousTarget == null)
        {
            OnChangeListOfTarget?.Invoke();
        }
        _previousTarget = _closestTarget;
    }
    public abstract List<Target> SortEntieits();
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        OnTrigger<T>(collision, (target) =>
        {
            _targets.RemoveAll(e => e == null);
            if (_targets.Contains(target))
            {
                _targets.Remove(target);
            }
        });
       // SortByObject();
    }*/
    private void OnDisable()
    {
       // TargetCreator.OnRemove -= RemoveTarget;
    }
}
