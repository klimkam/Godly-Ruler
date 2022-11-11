using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CheckerAngelNearby : CheckerEntitieNearby
{
    [SerializeField] private Demon _demon;
    private List<Angel> _angels = new List<Angel>();
    private Angel _closestAngel;
    public Angel ClosestAngel { get => _closestAngel; private set => _closestAngel = value; }
    public event Action OnChangeListOfAngels;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger<Angel>(collision, (angel) =>
        {
            _angels.Add(angel);
        });
        SortByObject(_demon.transform);
    }
    private void SortByObject(Transform target)
    {
        _angels.Sort(delegate (Angel firstAngel, Angel t2) 
        {
            return Vector3.Distance(firstAngel.transform.position,_demon.transform.position).CompareTo(Vector3.Distance(t2.transform.position, _demon.transform.position));
        });
        _angels = _angels.OrderByDescending(e => e is WarriorAngel).ToList();
        _closestAngel = _angels.FirstOrDefault();
        OnChangeListOfAngels?.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTrigger<Angel>(collision, (angel) =>
        {
            _angels.Remove(angel);
        });
        SortByObject(_demon.transform);
    }
}
