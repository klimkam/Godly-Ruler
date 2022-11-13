using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CheckerEntitieNearby : Trigger
{
    [SerializeField] private Target _parentTarget;
    [SerializeField] private float _radius = 6;
    [SerializeField] protected List<Target> _targets = new List<Target>();
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
        StartCoroutine(FindClosestEntitie());
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

    private IEnumerator FindClosestEntitie()
    {
        _closestTarget = null;
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_parentTarget.transform.position, _radius);
        //collider2Ds.ToList().ForEach(e => TryAdd(e));
        bool canSort = false;
        foreach (Collider2D collider2D in collider2Ds)
        {
            if (TryAdd(collider2D))
            {
                canSort = true;
            }
        }
        if (canSort)
        {
            Debug.Log("NEW ROAL!!!?!?! " + _parentTarget.name);
            SortByObject();
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(FindClosestEntitie());
    }
    public abstract bool TryAdd(Collider2D collider2D);
    public void SortByObject()
    {
        if (_targets == null)
        {
            return;
        }
        if (_targets.Count > _countOfTargets)
        {
            _targets.Sort(delegate (Target target1, Target target2)
            {
                return Vector3.Distance(target1.transform.position, _parentTarget.transform.position).CompareTo(Vector3.Distance(target2.transform.position, _parentTarget.transform.position));
            });
            if (_sorterEntitiesBy != null)
            {
                _targets = SortEntieits();
            }
        }
        if (_targets != null)
        {
            _closestTarget = _targets.FirstOrDefault();
            if (_closestTarget != _previousTarget || _previousTarget == null)
            {
                OnChangeListOfTarget?.Invoke();
            }
            _previousTarget = _closestTarget;
        }
        }
    public List<Target> SortEntieits()
    {
        return _sorterEntitiesBy.Sort(_targets);
    }
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
