using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ChangerCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _villagesForMinimap;
    [SerializeField] private List<TargetCreator> _targetCreators;
    private TargetCreator _currentTargetCreator;
    [SerializeField] private HumanVillage _humanVillage;
    private void Awake()
    {
        TurnOn(_villagesForMinimap[1]);
        _humanVillage.OnVillagePurification += ChangeCreatorToAngel;
        _humanVillage.OnVillagePossession += ChangeCreatorToDemon;
    }
    private void TurnOn(GameObject village)
    {
        _villagesForMinimap.ForEach(e => e.gameObject.SetActive(false));
        village.SetActive(true);
    }
    private void ChangeCreatorToAngel()
    {
        TurnOn(_villagesForMinimap.FirstOrDefault());
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
        TurnOn(_villagesForMinimap.LastOrDefault());
        _currentTargetCreator = _targetCreators.Find(e => e.Prefabs.All(a => a is Demon));
        TurnOnCreator();
    }
    private void OnDisable()
    {
        _humanVillage.OnVillagePurification -= ChangeCreatorToAngel;
        _humanVillage.OnVillagePossession -= ChangeCreatorToDemon;
    }
}
