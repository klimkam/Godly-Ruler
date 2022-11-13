using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ChangerCreator : MonoBehaviour
{
    [SerializeField] private List<TargetCreator> _targetCreators;
    private TargetCreator _currentTargetCreator;
    [SerializeField] private HumanVillage _humanVillage;
    private void Awake()
    {
        _humanVillage.OnVillagePurification += ChangeCreatorToAngel;
        _humanVillage.OnVillagePossession += ChangeCreatorToDemon;
    }
    private void ChangeCreatorToAngel()
    {
        Debug.LogError("ANGEL! ");
         _currentTargetCreator = _targetCreators.Find(e => e.Prefabs.All(a => a is Angel));
        TurnOnCreator();
    }
    private void TurnOnCreator()
    {
        _targetCreators.ForEach(e => e.gameObject.SetActive(false));
        _currentTargetCreator.gameObject.SetActive(true);
    }
    private void ChangeCreatorToDemon()
    {
        Debug.LogError("DEMON! ");
        _currentTargetCreator = _targetCreators.Find(e => e.Prefabs.All(a => a is Demon));
        TurnOnCreator();
    }
    private void OnDisable()
    {
        _humanVillage.OnVillagePurification -= ChangeCreatorToAngel;
        _humanVillage.OnVillagePossession -= ChangeCreatorToDemon;
    }
}
