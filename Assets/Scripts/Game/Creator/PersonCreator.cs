using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonCreator : Creator<Person>
{
    [SerializeField] private HumanVillage _humanVillage;
    private List<Person> _people = new List<Person>();
    [SerializeField] private TargetCreator _targetCreator;
    [SerializeField] private Vector2Int _bordersForCreating = new Vector2Int(0, 4);
    private void Awake()
    {
        int random = Random.Range(_bordersForCreating.x, _bordersForCreating.y);
        for (int i = 0; i < random; i++)
        {
            Debug.Log(_targetCreator.Points + " WE");
            Person person = Create(Prefabs.GetRandomElementFromList(), _targetCreator.Points.GetRandomElementFromList().position);
            person.Points = _targetCreator.Points;
            _humanVillage.OnVillagePurification += person.SetSimpleSprite;
            _humanVillage.OnVillagePossession += person.SetEvilSprite;
            _people.Add(person);
        }
        
    }
    private void OnDisable()
    {
        _people.ForEach(e =>
        {
            _humanVillage.OnVillagePurification -= e.SetSimpleSprite;
            _humanVillage.OnVillagePossession -= e.SetEvilSprite;
        });
    }
}
