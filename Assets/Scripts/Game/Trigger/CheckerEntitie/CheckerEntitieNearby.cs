using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CheckerEntitieNearby : Trigger
{
    [SerializeField] private bool _isHealer = false;
    [SerializeField] private Target _parentTarget;
    [SerializeField] private float _radius = 6;
    [SerializeField] protected List<Target> _targets = new List<Target>();
    protected Target _closestTarget;
    protected Target _previousTarget;
    protected SorterEntitiesBy _sorterEntitiesBy;
    private readonly int _countOfTargets = 1;
    private protected CollectorOfTargets _collectorOfTargets;
    private List<Target> _listOfCreatedTargets;
    public Target ClosestTarget { get => _closestTarget; private set => _closestTarget = value; }
    public SorterEntitiesBy SorterEntitiesBy { get => _sorterEntitiesBy; set => _sorterEntitiesBy = value; }
    public List<Target> ListOfCreatedTargets { get => _listOfCreatedTargets; set => _listOfCreatedTargets = value; }

    public event Action OnChangeListOfTarget;
    private void Start()
    {
        _collectorOfTargets = FindObjectOfType<CollectorOfTargets>();
       // _targetCreator = FindObjectOfType<TargetCreator>();
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
    public abstract List<Target> Create();
    private IEnumerator FindClosestEntitie()
    {
        FindClosest();
        yield return new WaitForSeconds(1);
        StartCoroutine(FindClosestEntitie());
    }
    public void FindClosest()
    {
        _closestTarget = null;
        //Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_parentTarget.transform.position, _radius);
        bool canSort = false;
        List<Target> targets = Create();
        if (_isHealer)
        {
            targets.Remove(_parentTarget);
        }
        if (targets != null)
        {
                List<Target> currentTargets = targets.FindAll(e => Vector2.Distance(_parentTarget.transform.position, e.transform.position) < _radius);
                if (currentTargets != null)
                {
                     if (currentTargets.Count > 0)
                   {
                    _targets = currentTargets;
                    canSort = true;

                   }
                }
        }
        //foreach (Collider2D collider2D in collider2Ds)
        //{
        //  if (TryAdd(collider2D))
        //{
        //    canSort = true;
        // }
        // }
        if (canSort)
        {
            SortByObject();
        }
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
            _targets.SortListByDistance(transform);
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
