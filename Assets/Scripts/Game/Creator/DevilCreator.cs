using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilCreator : Creator<Demon>
{
    [SerializeField] private int _countOfAngels = 6;
    [SerializeField] private Transform _point;
    private float _dectroyTime = 0.3f;
    private void Awake()
    {
        for (int i = 0; i < _countOfAngels; i++)
        {
            Demon demon = Create(_prefabs.GetRandomElementFromList(), _point.position);
            demon.Health.OnDie += Remove;        
        }
    }
    private void Remove(Health health)
    {
        Demon demon = ListOfCreatedPrefabs.Find(e => e.Health.CurrentHealth == health.CurrentHealth);
        demon.Health.OnDie -= Remove;
        ListOfCreatedPrefabs.Remove(demon);
        Destroy(demon.gameObject,_dectroyTime);
    }
    private void OnDisable()
    {
        ListOfCreatedPrefabs.ForEach(e => e.Health.OnDie -= Remove);
    }
}
